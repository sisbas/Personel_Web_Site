using System.ComponentModel.DataAnnotations;

namespace sisbas_mvc.Models
{
    public class Lead
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid company is required.")]
        public string Company { get; set; }
        
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "* A valid email address is required.")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "* A valid phone nunber is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
    }
}
