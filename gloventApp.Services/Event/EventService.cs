using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Event
{
    public class EventService : Service<evente>
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(factory);
        public EventService() : base(uow)
        {

        }

       


        public int GetNumberEvents()
        {


            return this.GetAllEvents().Count();


        }








        public int GetTodayNumberEvents()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Day.Equals(DateTime.Now.Day)).Count();


        }






       















        public IEnumerable<evente> GetTodayEvents()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Day.Equals(DateTime.Now.Day)).ToList();


        }






        public IEnumerable<evente> GetThisMonthEvents()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Month.Equals(DateTime.Now.Month)).ToList();


        }






















        public int GetNumberEventsThisMounth()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Month.Equals(DateTime.Now.Month)).Count();

        }



        public int GetNumberEventsLastMounth()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Month.Equals(DateTime.Now.AddMonths(-1).Month)).Count();

        }





      

        public int GetNumberEventsI(int i)
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Month.Equals(i)).Count();

        }



        public int GetNumberLastYearEvents()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Year.Equals(DateTime.Now.AddYears(-1).Year)).Count();

        }

        public int GetNumberLastYearEvents1()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Year.Equals(DateTime.Now.AddYears(-2).Year)).Count();


        }

        public int GetNumberthisYearEvents1()
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Year.Equals(DateTime.Now.Year)).Count();


        }


































        public List<int> GetNumberEventsEveryMonth()
        {
          //  IEnumerable<evente> le = GetAllEvents();
            List<int> num = new List<int>();
            for (int i = 1; i <num.Count; i++)
            {

                num[i] = uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Month.Equals(i)).Count();
            }
            return num;
           
        }


























        public IEnumerable<evente> GetAllEvents()
        {
            return uow.getRepository<evente>().GetMany().ToList();
        }





        public List<evente> GetNextWeekEvents()
        {
            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent>= DateTime.Now.AddDays(7) && e.dateEvent <= DateTime.Now.AddDays(14)).OrderBy(e => e.dateEvent).ToList();

            
        }

        public List<evente> GetLastWeekEvents()
        {

            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent<= DateTime.Now.AddDays(-7) && e.dateEvent >= DateTime.Now.AddDays(-14)).OrderBy(e => e.dateEvent).ToList();

           
        }


        public evente GetMostParticipationEvent()
        {
            return uow.getRepository<evente>().GetMany().OrderBy(e => -e.users.Count).FirstOrDefault();

            


           

        }





        public IEnumerable<evente> EventProchainAlaUneBycategoryEtDispo(category cat,organization org)
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.dateEvent.Value.Day>=DateTime.Now.AddDays(7).Day
            && e.dateEvent.Value.Day <= DateTime.Now.AddDays(14).Day && e.tickets.Count() >= 0 
            && e.Myo.Equals(org.id) && e.nombreParticipant>=100 && e.avaibility==true && e.category.Equals(cat));


        }




       











    }

}









    
