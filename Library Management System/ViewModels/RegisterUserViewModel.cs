using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8-100 characters")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
