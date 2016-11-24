using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gloventApp.Data.Infrastructure;
using gloventApp.Services.Organizationn;

namespace gloventApp.Services.Organizationn
{
    public class OrganizationService : Service<organization>,IOrganizationService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(factory);
        public OrganizationService() : base(utwk)
        {

        }

       public IEnumerable<organization> getAll()
        {
            return utwk.getRepository<organization>().GetMany().ToList();
        }

        public IEnumerable<organization> getByOrgLocation()
        {
            return utwk.getRepository<organization>().GetMany(o => o.Location != null).ToList();
        }
        
        
        //organization by events in this Month
        //woks !!
        public IEnumerable<organization> getOrganizationByEventsForCurrentMonth()
        {
            List<int?> x =utwk.getRepository<evente>()
                .GetMany(e => e.dateEvent.Value.Month.Equals( DateTime.Now.Month))
                .Select(f => f.Myo).ToList();
            List<organization> org = new List<organization>();

            foreach (var item in x)
            {
                organization u = utwk.getRepository<organization>().GetById((long)item);
                org.Add(u);
            }
            return org.ToList();
        }
             
         //validated
        public IEnumerable<organization> organizationByEventLocation(string localisation)
        {
            List<organization> or = new List<organization>();
            organization u = new organization();
            List<int?> e= utwk.getRepository<evente>().GetMany(f => f.localisation.Contains(localisation)).Select(z=>z.Myo).ToList();
            foreach (var item in e)
            {
                u = utwk.getRepository<organization>().GetById((long)item);
                or.Add(u);
            }
            return or.ToList();
        }




        //public IEnumerable<organization> organizationByEventLocationThisMonth(string location)
        //{
        //    return utwk.getRepository<evente>()
        //        .GetMany(f => (f.localisation.Length.Equals(location)) && (f.dateEvent.Month == DateTime.Now.Month))
        //        .Select(o => o.organization).ToList();
        //}



        public IEnumerable<organization> organizationByEventLocationsToday(DateTime d,string condition)//combobox now before after
        {
            if (condition == "after") { 
            return utwk.getRepository<evente>()
                .GetMany(f => (f.localisation.Length >= 0) && (f.dateEvent>d))
                .Select(o => o.organization).ToList();
            }
            else if (condition == "before")
            {
                return utwk.getRepository<evente>()
                .GetMany(f => (f.localisation.Length >= 0) && (f.dateEvent < d))
                .Select(o => o.organization).ToList();
            }else
                return utwk.getRepository<evente>()
                .GetMany(f => (f.localisation.Length >= 0) && (f.dateEvent.Value.Day==DateTime.Now.Day))
                .Select(o => o.organization).ToList();
        }

        public IEnumerable<organization> gettopOrganisationByAttendance()
        {
            return utwk.getRepository<user>().GetMany(e => e.events.Count >= 0).Select(f => f.organization).ToList();
        }


        // participant le plus present dans les evenements!!


        
        //public IEnumerable< organization >rankOrkganizationByEventsMonthly(int annee)
        //{
        //    //return utwk.getRepository<organization>().GetMany(e => e.events.Count>0).Where(f=>f.events).GroupBy(z => z.events).ToList();
        //    var e =
        //        from tab in utwk.getRepository<evente>().GetMany(f => f.dateEvent.Year.Equals(annee))
        //        group tab by tab.dateEvent.Month into g
        //        select new { myOrgani = g.Key, nombreEvent = g.OrderBy(k=>k.dateEvent.Month) };
        //    return e.ToList();

        //}

        public IEnumerable<organization> top5organizationByEvent(int annee)
        {
            return utwk.getRepository<organization>()
                .GetMany(e => e.events.Count > 0).OrderBy(z => z.events.Count).Take(5).ToList();
         }

        //public IEnumerable<organization> rankOrganizationByTicketCellforEvent()
        //{
        //    var listTicket = utwk.getRepository<evente>().GetMany(e => e.tickets.Count >= 0).(t => t.tickets).ToList();

        //    foreach (var item in listTicket)
        //    {

        //    }
            
        //}


    }
}
