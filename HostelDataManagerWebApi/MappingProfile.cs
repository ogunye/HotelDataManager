using AutoMapper;
using HostelDataManagerDomain.Entities;
using HostelDataManagerShared.DataTransferObjects.EmployeeDTOs;
using HostelDataManagerShared.DataTransferObjects.HostelDTOs;
using HostelDataManagerShared.DataTransferObjects.UserDTO;

namespace HostelDataManagerWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HostelForCreateionDto, HostelCompany>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<HostelForUpdateDto, HostelCompany>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<HostelCompany, HostelDto>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
