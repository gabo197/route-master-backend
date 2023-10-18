using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Persistence.Repos;

namespace RouteMaster.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepo companyRepo;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(ICompanyRepo companyRepo, IUnitOfWork unitOfWork)
        {
            this.companyRepo = companyRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await companyRepo.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found");

            try
            {
                companyRepo.Remove(existingCompany);
                await unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while deleting the company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> GetByIdAsync(int id)
        {
            var existingCompany = await companyRepo.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            return new CompanyResponse(existingCompany);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await companyRepo.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await companyRepo.AddAsync(company);
                await unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while saving the company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await companyRepo.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found");

            existingCompany.Name = company.Name;

            try
            {
                companyRepo.Update(existingCompany);
                await unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error ocurred while updating the company: {ex.Message}");
            }
        }
    }
}
