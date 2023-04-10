using HostelDataManagerApplication.Contracts;
using HostelDataManagerDomain.Entities;
using HostelDataManagerInfrastructure.BaseRepositories;
using HostelDataManagerInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace HostelDataManagerInfrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeForHostel(int hostelId, Employee employee)
        {
            employee.HostelId = hostelId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int hostelId, int employeeId, bool trackChanges)
        {
            var employee = await FindByCondition(e => e.HostelId.Equals(hostelId) && e.Id.Equals(employeeId), trackChanges)
                .SingleOrDefaultAsync();

            if (employee == null)
            {
                throw new Exception($"Employee with ID {employeeId} not found in hostel with ID {hostelId}");
            }
            return employee;
        }


        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int hostelId, bool trackChanges)
        {
            return await FindByCondition(c=> c.HostelId.Equals(hostelId), trackChanges)
                .OrderBy(x=> x.Id)
                .ToListAsync();
        }
    }
}
