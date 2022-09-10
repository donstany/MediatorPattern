using FluentValidation;

namespace BLL.Values.Commands.CreateValueCommand
{
    public class CreateValueCommandValidator : AbstractValidator<CreateValueCommand>
    {
        public CreateValueCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
