using Pryaniki.Models;

namespace Pryaniki.Services
{
    public class StorageService
    {
        private List<Event> _events = new();

        public IEnumerable<Event> Events => _events;

        public void AddEvent(Event action)
        {
            action.DateTime = DateTime.UtcNow;
            _events.Add(action);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
