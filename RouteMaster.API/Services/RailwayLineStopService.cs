using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class RailwayLineStopService : IRailwayLineStopService
    {
        private readonly IRailwayLineStopRepo _railwayLineStopRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RailwayLineStopService(IRailwayLineStopRepo railwayLineStopRepo, IUnitOfWork unitOfWork)
        {
            _railwayLineStopRepo = railwayLineStopRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<RailwayLineStopResponse> SaveAsync(RailwayLineStop railwayLineStop)
        {
            try
            {
                await _railwayLineStopRepo.AddAsync(railwayLineStop);
                await _unitOfWork.CompleteAsync();

                return new RailwayLineStopResponse(railwayLineStop);
            }
            catch (Exception ex)
            {
                return new RailwayLineStopResponse($"An error occurred when saving the railway line stop: {ex.Message}");
            }
        }
    }
}