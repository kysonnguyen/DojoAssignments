using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public abstract class BaseEntity {}

    public class User
    {   
        [Required]
        [MinLength(4)]
        public string Fname { get; set; }
        
        [Required]
        [MinLength(4)]
        public string Lname { get; set; }

        [Required]
        [Range(1,200)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}