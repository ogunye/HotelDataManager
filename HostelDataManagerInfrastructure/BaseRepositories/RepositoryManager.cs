using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerApplication.Contracts;
using HostelDataManagerInfrastructure.DataContext;
using HostelDataManagerInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerInfrastructure.BaseRepositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoriesContext;
        private readonly Lazy<IHostelRepository> _hostelRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoriesContext = repositoryContext;
            _hostelRepository = new Lazy<IHostelRepository>(() => new HostelRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }

        public IHostelRepository Hostel => _hostelRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public async Task SaveAsync() 
            => await _repositoriesContext.SaveChangesAsync();
    }
}
