using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerServiceContract
{
    public interface IServiceManager
    {
        IHostelCompanyService HostelCompanyService { get; }
        IEmployeeService EmployeeService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
