using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class CompanyRepo : BaseRepo, ICompanyRepo
    {
        public CompanyRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company?> FindByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}
