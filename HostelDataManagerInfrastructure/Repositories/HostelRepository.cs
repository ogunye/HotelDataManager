using HostelDataManagerApplication.Contracts;
using HostelDataManagerDomain.Entities;
using HostelDataManagerInfrastructure.BaseRepositories;
using HostelDataManagerInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerInfrastructure.Repositories
{
    internal sealed class HostelRepository : RepositoryBase<HostelCompany>, IHostelRepository
    {
        public HostelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateHostel(HostelCompany company) => Create(company);

        public void DeleteHostel(HostelCompany company) => Delete(company);

        public async Task<IEnumerable<HostelCompany>> GetAllHostelsAsync(bool trackChanges)
            => await FindAll(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();

        public async Task<IEnumerable<HostelCompany>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) 
            => await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

        public async Task<HostelCompany> GetHostelAsync(int id, bool trackChanges)
            => await FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
