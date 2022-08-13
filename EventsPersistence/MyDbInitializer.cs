using EventsDomain.Entities;

namespace EventsPersistence
{
    public static class MyDbInitializer
    {
        public static List<Event> Initialize()
        {
            return new List<Event>()
            {
                new Event { Description = "Event1", Plan = "Plan1", Speaker = "Speaker1", Sponsor = "Sponsor1",
                            Title = "Title1", Time = DateTime.Now, Venue = "Minsk", Id = 1 },
                new Event { Description = "Event2", Plan = "Plan2", Speaker = "Speaker2", Sponsor = "Sponsor2",
                            Title = "Title2", Time = DateTime.Now, Venue = "Minsk", Id = 2 },
                new Event { Description = "Event3", Plan = "Plan3", Speaker = "Speaker3", Sponsor = "Sponsor3",
                            Title = "Title3", Time = DateTime.Now, Venue = "Minsk", Id = 3 },
                new Event { Description = "Event4", Plan = "Plan4", Speaker = "Speaker4", Sponsor = "Sponsor4",
                            Title = "Title4", Time = DateTime.Now, Venue = "Minsk", Id = 4 },
            };
        }
    }
}
