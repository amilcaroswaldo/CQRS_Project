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
            ValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
        public List<string> ValidationErrors { get; set; }
    }
}
