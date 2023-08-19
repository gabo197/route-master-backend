using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo countryRepo;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(ICountryRepo countryRepo, IUnitOfWork unitOfWork)
        {
            this.countryRepo = countryRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await countryRepo.ListAsync();
        }
    }
}
