using MediatR;
using EventsApplication.Interfaces;
using EventsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using EventsApplication.Common.Exceptions;

namespace EventsApplication.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventDbContext _dbContext;

        public UpdateEventCommandHandler(IEventDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            entity.Venue = request.Venue;
            entity.Plan = request.Plan;
            entity.Title = request.Title;
            entity.Sponsor = request.Sponsor;
            entity.Speaker = request.Speaker;
            entity.Description = request.Description;
            entity.Time = request.Time;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
