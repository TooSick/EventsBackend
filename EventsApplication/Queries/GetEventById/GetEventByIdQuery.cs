using MediatR;

namespace EventsApplication.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventByIdVm>
    {
        public int Id { get; set; }
    }
}
