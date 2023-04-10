using HostelDataManagerApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerApplication.CommonContracts
{
    public interface IRepositoryManager
    {
        IHostelRepository Hostel { get; }
        IEmployeeRepository Employee { get; }
        Task SaveAsync();
    }
}
