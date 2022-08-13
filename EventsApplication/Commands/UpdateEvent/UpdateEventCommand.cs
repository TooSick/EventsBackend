using MediatR;

namespace EventsApplication.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string Speaker { get; set; }
        public string Sponsor { get; set; }
    }
}
