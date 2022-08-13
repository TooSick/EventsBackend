using Microsoft.EntityFrameworkCore;
using EventsDomain.Entities;
using EventsApplication.Interfaces;

namespace EventsPersistence
{
    public class EventsDbContext : DbContext, IEventDbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().HasKey(e => e.Id);
            builder.Entity<Event>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Event>().HasData(MyDbInitializer.Initialize());
            base.OnModelCreating(builder);  
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch(DbUpdateException ex)
            {
                throw;
            }
            catch(OperationCanceledException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
