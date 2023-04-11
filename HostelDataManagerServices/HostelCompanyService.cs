using AutoMapper;
using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerDomain.Entities;
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

        public async Task<HostelDto> CreateHostelCompany(HostelForCreateionDto hostelForCreateionDto)
        {
            var hotelEntity = _mapper.Map<HostelCompany>(hostelForCreateionDto);

            _repository.Hostel.CreateHostel(hotelEntity);
            await _repository.SaveAsync();

            var hotelToReturn = _mapper.Map<HostelDto>(hotelEntity);

            return hotelToReturn;
        }

        public async Task DeleteHostelCompanyAsync(int hostelId, bool trackChanges)
        {
            var hostel = await _repository.Hostel.GetHostelAsync(hostelId, trackChanges);
            if (hostel == null)
            {
                //throw new HostelCompanyNotFoundExpection(hostelId);
            }
            _repository.Hostel.DeleteHostel(hostel);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<HostelDto>> GetAllHostelsAsync(bool trackChange)
        {
            var hostelEntities = await _repository.Hostel.GetAllHostelsAsync(trackChange);

            var hostelsToReturn = _mapper.Map<IEnumerable<HostelDto>>(hostelEntities);

            return hostelsToReturn;
        }

        public async Task<IEnumerable<HostelDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChange)
        {
            if(ids is null)
            {
                //throw new IdParametersBadRequestException();
            }

            var hostelEntities = await _repository.Hostel.GetByIdsAsync(ids, trackChange);
            if(ids.Count() != hostelEntities.Count())
            {
                //throw new CollectionByIdsBadRequestException();
            }

            var hostelsToReturn = _mapper.Map<IEnumerable<HostelDto>>(hostelEntities);
            return hostelsToReturn;
        }

        public async Task<HostelDto> GetHostelCompanyAsync(int hostelId, bool trackChange)
        {
            var hostel = await _repository.Hostel.GetHostelAsync(hostelId, trackChange);
            if(hostel == null)
            {
                //throw new HostelNotFoundException(hostelId);
            }
             var hostelDto = _mapper.Map<HostelDto>(hostel);
            return hostelDto;
        }

        public async Task UpdateHostelAsync(int hostelId, HostelForUpdateDto hostelForUpdateDto, bool trackChanges)
        {
            var hostelEntity = await _repository.Hostel.GetHostelAsync(hostelId, trackChanges);

            if(hostelEntity is null)
            {
                //throw new HostelNotFoundException(hostelId);
            }
            _mapper.Map(hostelForUpdateDto, hostelEntity);

            await _repository.SaveAsync();
        }
    }
}
