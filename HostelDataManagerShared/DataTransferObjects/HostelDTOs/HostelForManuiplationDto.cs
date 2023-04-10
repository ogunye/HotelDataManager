using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerShared.DataTransferObjects.HostelDTOs
{
    public abstract record HostelForManuiplationDto
    {
        [Required(ErrorMessage ="Hostel Name is a required field.")]
        [MaxLength(100, ErrorMessage ="maxiumum lenght for Name is 100 character")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "Hostel Address is a required field.")]
        [MaxLength(500, ErrorMessage = "maxiumum lenght for Name is 500 character")]
        public string? HostelAddress { get; set; }

        [MaxLength(5, ErrorMessage ="Maxiumum lenght for rank is 5 characters")]
        public string? HotelRank { get; set; }
    }
}
