using AutoMapper;
using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerServiceContract;
using HostelDataManagerShared.DataTransferObjects.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerServices
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<EmployeeDto> CreateEmployeeForHotelAsync(int hotelId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeForHotelAsync(int hotelId, int employeeId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int hotelId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetEmployeesAsync(int hotelId, int employeeId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeForHotelAsync(int hotelId, int employeeId, EmployeeForUpdateDto employeeForUpdate, bool hotelTrackChanges, bool empTrackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
