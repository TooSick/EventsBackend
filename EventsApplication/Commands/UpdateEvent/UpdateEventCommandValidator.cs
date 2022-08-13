using FluentValidation;

namespace EventsApplication.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(updateEventCommand => updateEventCommand.Id).NotEmpty();
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
