using System.ComponentModel.DataAnnotations;

namespace NQWebb.Models.ViewModels
{
    public class ContactFormVM
    {
        [Required]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
