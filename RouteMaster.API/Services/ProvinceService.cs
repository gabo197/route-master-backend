using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepo provinceRepo;
        private readonly IUnitOfWork unitOfWork;

        public ProvinceService(IProvinceRepo provinceRepo, IUnitOfWork unitOfWork)
        {
            this.provinceRepo = provinceRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Province>> ListAsync()
        {
            return await provinceRepo.ListAsync();
        }
    }
}
