using System.Collections.Generic;
using System.Linq;
using Models;
using Data;

namespace Services
{
    public class EventService
    {
        public void CreateEvent(Event ev)
        {
            AppDb.Events.Add(ev);
        }

        public List<Event> GetByCategory(int categoryId)
        {
            return AppDb.Events.Where(e => e.CategoryId == categoryId).ToList();
        }
    }
}