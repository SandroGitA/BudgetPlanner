using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.API.DTO
{
    public record RegisterUserRequest(
        [Required] string Username,
        [Required] string Email,
        [Required] string Password);
}
