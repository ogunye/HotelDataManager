using HostelDataManagerShared.DataTransferObjects.HostelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerServiceContract
{
    public interface IHostelCompanyService
    {
        Task<IEnumerable<HostelDto>> GetAllHostelsAsync(bool trackChange);
        Task<HostelDto> GetHostelCompanyAsync(int hostelId,  bool trackChange);
        Task<HostelDto> CreateHostelCompany(HostelForCreateionDto hostelForCreateionDto);
        Task<IEnumerable<HostelDto>> GetByIdsAsync(IEnumerable<int> ids,  bool trackChange);

        Task UpdateHostelAsync(int hostelId, HostelForUpdateDto hostelForUpdateDto, bool trackChanges);
        Task DeleteHostelCompanyAsync(int hostelId, bool trackChanges);
    }
}
