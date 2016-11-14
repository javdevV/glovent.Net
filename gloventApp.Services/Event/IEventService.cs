using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Event
{
    public interface IEventService : IService<evente>
    {
        void updateEvent(int id);
        evente GetEventById(int id);
        void DeleteEvent(int id);
       
        IEnumerable<evente> GetAllEvents();
        evente GetMostParticipationEvent();
        List<evente> GetLastWeekEvents();
        List<evente> GetNextWeekEvents();










    }
}
