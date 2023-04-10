using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerShared.DataTransferObjects.EmployeeDTOs
{
    public abstract record EmplyeeForManpluationDto
    {
        [Required(ErrorMessage ="Hostel Id is a required 3field.")]
        public int HostelId { get; set; }

        [Required(ErrorMessage ="Employee First Name is a required field.")]
        [MaxLength(50, ErrorMessage ="Maximum lenght for FirstName is 50 character.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum lenght for LastName is 50 character.")]
        public string? LastName { get; set; }

        [MaxLength(50,ErrorMessage ="Maximum length for Email is 50 characters")]
        public string? EmailAddress { get; set; }

        [MaxLength(11, ErrorMessage ="Maximum lenght for Phone Number is 11 characters")]
        public string? PhoneNumber { get; set; }
    }
}
