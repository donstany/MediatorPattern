using FluentValidation;

namespace BLL.Values.Commands.DeleteValueCommand
{
    public class DeleteValueCommandValidator : AbstractValidator<DeleteValueCommand>
    {
        public DeleteValueCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
