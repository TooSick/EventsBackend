using MediatR;
using EventsDomain.Entities;
using EventsApplication.Interfaces;

namespace EventsApplication.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventDbContext _dbContext;

        public CreateEventCommandHandler(IEventDbContext dbContext) => _dbContext = dbContext;

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var ev = new Event
            {
                Title = request.Title,
                Description = request.Description,
                Plan = request.Plan,
                Time = request.Time,
                Venue = request.Venue,
                Speaker = request.Speaker,
                Sponsor = request.Sponsor,
            };
  
            await _dbContext.Events.AddAsync(ev);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ev.Id;
        }
    }
}
