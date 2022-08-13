using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EventsApplication.Interfaces;

namespace EventsPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EventsDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEventDbContext>(provider => provider.GetService<EventsDbContext>());
            return services;
        }
    }
}
