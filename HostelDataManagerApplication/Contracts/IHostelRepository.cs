using HostelDataManagerDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerApplication.Contracts
{
    public interface IHostelRepository
    {
        Task<IEnumerable<HostelCompany>> GetAllHostelsAsync(bool trackChanges);
        Task<HostelCompany> GetHostelAsync(int id, bool trackChanges);
        Task<IEnumerable<HostelCompany>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteHostel(HostelCompany company);
        void CreateHostel(HostelCompany company);
    }
}
