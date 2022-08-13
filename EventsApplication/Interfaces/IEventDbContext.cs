using Microsoft.EntityFrameworkCore;
using EventsDomain.Entities;

namespace EventsApplication.Interfaces
{
    public interface IEventDbContext
    {
        public DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
