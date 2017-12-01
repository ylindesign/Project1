using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project1.Models {
    public class RegisterViewModel : BaseEntity {
        [Display(Name = "First Name")]
        [Required]
        [FirstNameAttribute]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [LastNameAttribute]
        public string last_name { get; set; }
 
        [Display(Name = "Email")]
        [Required(ErrorMessage="Email field is required.")]
        [EmailAddress(ErrorMessage="Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
 
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [PasswordAttribute]
        public string password { get; set; }
 
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords must match.")]
        public string pw_conf { get; set; }
    }
}