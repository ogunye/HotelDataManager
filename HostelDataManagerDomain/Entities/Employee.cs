using HostelDataManagerDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerDomain.Entities
{
    public class Employee : AuditableBaseEntity
    {
        [ForeignKey(nameof(HostelCompany))]
        public int HostelId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

        public HostelCompany? HostelCompany { get; set; }
    }
}
