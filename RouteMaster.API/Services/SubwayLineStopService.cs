using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class SubwayLineStopService : ISubwayLineStopService
    {
        private readonly ISubwayLineStopRepo _subwayLineStopRepo;
        private readonly IUnitOfWork _unitOfWork;

        public SubwayLineStopService(ISubwayLineStopRepo subwayLineStopRepo, IUnitOfWork unitOfWork)
        {
            _subwayLineStopRepo = subwayLineStopRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<SubwayLineStopResponse> SaveAsync(SubwayLineStop subwayLineStop)
        {
            try
            {
                await _subwayLineStopRepo.AddAsync(subwayLineStop);
                await _unitOfWork.CompleteAsync();

                return new SubwayLineStopResponse(subwayLineStop);
            }
            catch (Exception ex)
            {
                return new SubwayLineStopResponse($"An error occurred when saving the subway line stop: {ex.Message}");
            }
        }
    }
}