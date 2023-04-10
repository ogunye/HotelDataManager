using HostelDataManagerDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerApplication.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int hostelId, bool trackChanges);
        Task<Employee> GetEmployeeAsync(int hostelId,  int employeeId, bool trackChanges);
        void DeleteEmployee(Employee employee);
        void CreateEmployeeForHostel(int hostellId, Employee employee);
    }
}
