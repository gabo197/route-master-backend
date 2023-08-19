using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentService(IDepartmentRepo departmentRepo, IUnitOfWork unitOfWork)
        {
            this.departmentRepo = departmentRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await departmentRepo.ListAsync();
        }
    }
}
