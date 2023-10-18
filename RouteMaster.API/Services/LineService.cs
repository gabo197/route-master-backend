using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class LineService : ILineService
    {
        private readonly ILineRepo lineRepo;

        public LineService(ILineRepo lineRepo)
        {
            this.lineRepo = lineRepo;
        }
        public async Task<IEnumerable<Line>> ListAsync()
        {
            return await lineRepo.ListAsync();
        }
    }
}
