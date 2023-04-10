using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerDomain.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [StringLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        [StringLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDelete { get; set; }
    }
}
