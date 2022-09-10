using FluentValidation;

namespace BLL.Requests.ValuesRequest
{
    public class ValueRequestValidator : AbstractValidator<ValueRequest>
    {
        public ValueRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).Must(x => !IsNumeric(x)).WithMessage("The value must be numeric!");
        }

        private bool IsNumeric(object value)
        {
            if (value == null)
            {
                return false;
            }

            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
