using FluentValidation;

namespace EventsApplication.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Description).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Title).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Plan).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Speaker).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Sponsor).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Venue).NotEmpty();
        }
    }
}
