using Microsoft.EntityFrameworkCore;
using Pryaniki.Models;

namespace Pryaniki.Data
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; init; } = null!;

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
