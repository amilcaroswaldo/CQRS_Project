using Microsoft.AspNetCore.Mvc;

namespace leave_management.Api.Middelware.Models
{
    public class CostomValidatorsProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Erros { get; set; } = new Dictionary<string, string[]>();
    }
}
