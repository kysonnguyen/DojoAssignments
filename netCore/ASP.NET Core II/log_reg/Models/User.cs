using System.ComponentModel.DataAnnotations;

namespace log_reg.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {   
        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Password must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Password_conf { get; set; }
    }
}