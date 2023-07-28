using FluentValidation.Results;

namespace leave_management.Application.Exceptions
{
    public class BadRequestExceptions : Exception
    {
        public BadRequestExceptions(string message) : base(message)
        {
        }

        public BadRequestExceptions(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
