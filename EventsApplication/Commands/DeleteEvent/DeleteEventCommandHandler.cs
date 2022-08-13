using MediatR;
using EventsApplication.Interfaces;
using EventsApplication.Common.Exceptions;
using EventsDomain.Entities;

namespace EventsApplication.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventDbContext _dbContext;

        public DeleteEventCommandHandler(IEventDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
