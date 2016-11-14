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
    public class EventService : Service<evente>, IEventService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(factory);
        public EventService() : base(uow)
        {

        }

        public void DeleteEvent(int id)
        {
            evente e = GetEventById(id);
            uow.getRepository<evente>().Delete(e);
            uow.Commit();
        }

        public evente GetEventById(int id)
        {
            foreach (evente e in GetAllEvents())
            {
                if (e.idEvent == id)
                    return e;
            }
            return null;
        }

        public void updateEvent(int id)
        {
            evente e = GetEventById(id);   
            uow.getRepository<evente>().Update(e);
            uow.Commit();
        }


        public IEnumerable<evente> GetAllEvents()
        {
            return uow.getRepository<evente>().GetMany().ToList();
        }





        public List<evente> GetNextWeekEvents()
        {
            var evts = uow.getRepository<evente>().GetMany().Where(e => e.dateEvent>= DateTime.Now.AddDays(7) && e.dateEvent <= DateTime.Now.AddDays(14)).OrderBy(e => e.dateEvent).ToList();

            return evts;
        }

        public List<evente> GetLastWeekEvents()
        {

            var evts = uow.getRepository<evente>().GetMany().Where(e => e.dateEvent<= DateTime.Now.AddDays(-7) && e.dateEvent >= DateTime.Now.AddDays(-14)).OrderBy(e => e.dateEvent).ToList();

            return evts;
        }


        public evente GetMostParticipationEvent()
        {
            var evt = uow.getRepository<evente>().GetMany().OrderBy(e => -e.tickets.Count).FirstOrDefault();

            return evt;
        }







    }

}









    
