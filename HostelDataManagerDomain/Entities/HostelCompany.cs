using HostelDataManagerDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerDomain.Entities
{
    public class HostelCompany : AuditableBaseEntity
    {
        public string? HotelName { get; set; }
        public string? HostelAddress { get; set; }
        public string? HotelRank { get; set; }

        public ICollection<Employee>? Employees { get; set;}
    }
}
