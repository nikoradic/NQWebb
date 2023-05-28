using System.ComponentModel.DataAnnotations;

namespace NQWebb.Models.ViewModels
{
    public class UserRegistartionVM
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

    }
}
