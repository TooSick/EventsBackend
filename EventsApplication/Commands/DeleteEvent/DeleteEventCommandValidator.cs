using FluentValidation;

namespace EventsApplication.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(deleteEventCommand => deleteEventCommand.Id).NotEmpty();

        }
    }
}
