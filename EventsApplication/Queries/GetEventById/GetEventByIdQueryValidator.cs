using FluentValidation;

namespace EventsApplication.Queries.GetEventById
{
    public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
    {
        public GetEventByIdQueryValidator()
        {
            RuleFor(ev => ev.Id).NotEmpty();
        }
    }
}
