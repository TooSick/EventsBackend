namespace EventsPersistence
{
    public class DbInitializer
    {
        public static void Initialize(EventsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
