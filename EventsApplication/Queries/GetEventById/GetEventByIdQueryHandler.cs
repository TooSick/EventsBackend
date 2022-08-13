using MediatR;
using EventsApplication.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EventsApplication.Common.Exceptions;
using EventsDomain.Entities;

namespace EventsApplication.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventByIdVm>
    {
        private readonly IEventDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IEventDbContext dbContext, IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventByIdVm> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FirstOrDefaultAsync(ev => ev.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            return _mapper.Map<EventByIdVm>(entity);
        }
    }
}
