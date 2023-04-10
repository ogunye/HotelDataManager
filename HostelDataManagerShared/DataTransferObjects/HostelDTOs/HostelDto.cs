using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerShared.DataTransferObjects.HostelDTOs
{
    public record HostelDto
    {
        public int Id { get; init; }
        public string? HostelName { get; init; }
        public string? HostelAddress { get; init; }
        public string? HostelRank { get; init;  }
    }
}
