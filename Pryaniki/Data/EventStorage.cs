using Pryaniki.Models;

namespace Pryaniki.Data
{
    public class EventStorage : IEventStorage
    {
        private readonly EventContext _context;

        public EventStorage(EventContext context)
        {
            _context = context;
        }

        public void AddEvent(Event action)
        {
            action.DateTime = DateTime.UtcNow;
            _context.Events.Add(action);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetEvents(DateTime from)
        {
            return _context.Events.Where(e => e.DateTime >= from);
        }
    }
}
