using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerShared.DataTransferObjects.EmployeeDTOs
{
    public record EmployeeDto
    {
        public int Id { get; init; }
        public int HostelId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? EmailAddress { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
