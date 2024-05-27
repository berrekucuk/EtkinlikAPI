using Microsoft.EntityFrameworkCore;

namespace EtkinlikAPI.Models.ORM
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
