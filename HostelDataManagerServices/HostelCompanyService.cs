using AutoMapper;
using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerServiceContract;
using HostelDataManagerShared.DataTransferObjects.HostelDTOs;

namespace HostelDataManagerServices
{
    internal sealed class HostelCompanyService : IHostelCompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public HostelCompanyService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<HostelDto> CreateHostelCompany(HostelForCreateionDto hostelForCreateionDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHostelCompanyAsync(int hostelId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HostelDto>> GetAllHostelsAsync(bool trackChange)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HostelDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChange)
        {
            throw new NotImplementedException();
        }

        public Task<HostelDto> GetHostelCompanyAsync(int hostelId, bool trackChange)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHostelAsync(int hostelId, HostelForUpdateDto hostelForUpdateDto, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
