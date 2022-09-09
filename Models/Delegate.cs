using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Models
{
    public class Delegate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DelegateID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Dietary requirement is required")]
        public string DietaryRequirement { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Delegate physical address is required")]
        public string DelegatePhysicalAddress { get; set; }
        [Required(ErrorMessage = "Delegate postal address is required")]
        public string DelegatePostalAddress { get; set; }
    }
}
