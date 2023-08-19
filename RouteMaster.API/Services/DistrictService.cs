using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepo districtRepo;
        private readonly IUnitOfWork unitOfWork;

        public DistrictService(IDistrictRepo districtRepo, IUnitOfWork unitOfWork)
        {
            this.districtRepo = districtRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await districtRepo.ListAsync();
        }
    }
}
