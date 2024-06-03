using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.API.DTO
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
