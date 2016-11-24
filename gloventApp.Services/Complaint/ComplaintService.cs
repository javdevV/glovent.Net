using glovent.App.Services;
using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using gloventApp.Services.Organizationn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Complaint
{
    public class ComplaintService :Service<complaint>
    {

        public static IDatabaseFactory dbf = new DatabaseFactory();
        public static IUnitOfWork uw = new UnitOfWork(dbf);
        UserService us = new UserService();
        public ComplaintService() : base(uw) { }

        public IEnumerable<complaint> getAll()
        {
            return uw.getRepository<complaint>().GetMany().ToList();
        }
     /**** recherche */
        public IEnumerable<complaint> complaintsBySubject(string type)
        {
            return uw.getRepository<complaint>().GetMany(a => a.Subject.Equals(type))
                .OrderByDescending(a=>a.creationDate).ToList();
        }
        public IEnumerable<complaint> complaintsByImportance(string level)
        {
            return uw.getRepository<complaint>().GetMany(a => a.importanceLvl.Equals(level))
                .OrderByDescending(a => a.creationDate).ToList();
        }

        public IEnumerable<complaint> ComplaintsByDay(DateTime d)
        {
            return uw.getRepository<complaint>().GetMany(a => (a.creationDate.Year == d.Year) &&
                (a.creationDate.Month == d.Month) && (a.creationDate.Day == d.Day)).ToList();
        }

        public IEnumerable<complaint> complaintsByMonth(DateTime d)
        {
            return uw.getRepository<complaint>().GetMany(a => (a.creationDate.Year == d.Year) &&
                (a.creationDate.Month == d.Month)).ToList();
        }
        public int nbComplaintsByMonth(DateTime d)
        {
            return uw.getRepository<complaint>().GetMany(a => (a.creationDate.Year == d.Year) &&
                (a.creationDate.Month == d.Month)).Count();
        }
        public IEnumerable<complaint> ComplaintsByEvent(string evente)
        {
            return uw.getRepository<complaint>().GetMany(a => (a.Subject.ToLower().Equals("event") && 
                a.Description.Contains(evente))).ToList();
        }
      
        public IEnumerable<complaint> ComplaintsByOrganization(string org)
        {
            return uw.getRepository<complaint>().GetMany(a => (a.Subject.ToLower().Equals("organization") &&
                a.Description.Contains(org))).ToList();
          
        }
     
        //mostReportedOrganizations
        public IEnumerable<organization> mostReportedOrganizations()
        {
            OrganizationService os = new OrganizationService();
            List<organization> lst =os.GetMany().ToList();
            List<organization> listre = new List<organization>();
            int max=0;
            //chercher le max
            foreach (organization o in lst)
            {
                int nb = this.ComplaintsByOrganization(o.name).Count();
                if (nb >= max)
                {max = nb; }
            }
                //remplir la liste des max
                foreach (organization o in lst)
                {
                     int nb = this.ComplaintsByOrganization(o.name).Count();
                    if (nb == max)
                    {
                        listre.Add(os.GetMany(a => a.name.Equals(o.name)).First());
                    }

                }
            return listre; 
        }
        //user envoi le + de complaint
        public IEnumerable<user> mostActiveUserthisMonth()
        {
            //int i = (int)uw.getRepository<complaint>().GetMany(a => (a.creationDate.Month == DateTime.Now.Month) && (a.creationDate.Day == DateTime.Now.Day))
            //    .GroupBy(a => a.MyUser_idUser).Max().Select(b => b.MyUser_idUser).First();

            List<user> lst = us.GetMany().ToList();
            List<user> listre = new List<user>();
            int max = 0;
            //chercher le max
            foreach (user o in lst)
            {
                int nb = uw.getRepository<complaint>().GetMany(a => (a.MyUser_idUser == o.Id && a.creationDate.Month == DateTime.Now.Month 
                && a.creationDate.Year == DateTime.Now.Year)).Count();
                if (nb >= max)
                { max = nb; }
            }
            //remplir la liste des max
            foreach (user o in lst)
            {
                int nb = uw.getRepository<complaint>().GetMany(a => (a.MyUser_idUser == o.Id && a.creationDate.Month == DateTime.Now.Month 
                && a.creationDate.Year == DateTime.Now.Year)).Count();
                if (nb == max)
                {
                    listre.Add(o);
                }
            }
            return listre;
        }

    /******** for notifications  */

        //fonction nb org à creer = nb president without org
        public int presidentWithoutOrg()
        {
            return uw.getRepository<user>().GetMany(a => (a.DTYPE.ToLower().Equals("president") && a.MyOrganization_id == null)).Count();
        }

        public IEnumerable<complaint> complaintsToday()
        {
            DateTime d = DateTime.Now;
            return uw.getRepository<complaint>().GetMany(a => (a.creationDate.Year == d.Year) &&
            (a.creationDate.Month == d.Month) && (a.creationDate.Day == d.Day)).ToList();
        }
       public IEnumerable<user> usersComplaintNG()
        {
            //return  uw.getRepository<user>().GetMany().SelectMany(a => a.complaints).Where(a => a.gere == false).Select(y=>y.user).ToList();
            List<int?> x = uw.getRepository<complaint>().GetMany(a => a.gere == false).Select(a => a.MyUser_idUser).ToList();
            List<user> listOfUser = new List<user>();
            foreach (int c in x)
            {
                listOfUser.Add(us.GetById(c));
            }
            return listOfUser;
        }
        public IEnumerable<complaint> complaintNGOfUser(user u )
        {
            return uw.getRepository<complaint>().GetMany(a => (a.gere == false && a.MyUser_idUser==u.Id )).ToList();
        }

    }
}
