using HostelDataManagerShared.DataTransferObjects.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerServiceContract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int hotelId, bool trackChanges);
        Task<EmployeeDto> GetEmployeesAsync(int hotelId, int employeeId,  bool trackChanges);
        Task<EmployeeDto> CreateEmployeeForHotelAsync(int hotelId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges);
        Task UpdateEmployeeForHotelAsync(int hotelId, int employeeId, EmployeeForUpdateDto employeeForUpdate, bool hotelTrackChanges, bool empTrackChanges);
        Task DeleteEmployeeForHotelAsync(int hotelId, int employeeId, bool trackChanges);
    }
}
