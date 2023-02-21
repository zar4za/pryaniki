using Pryaniki.Models;

namespace Pryaniki.Data
{
    public interface IEventStorage
    {
        void AddEvent(Event action);
        IEnumerable<Event> GetEvents(DateTime from);
    }
}
