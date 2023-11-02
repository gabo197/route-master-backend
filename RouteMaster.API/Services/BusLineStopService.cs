using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class BusLineStopService : IBusLineStopService
    {
        private readonly IBusLineStopRepo _busLineStopRepo;
        private readonly IUnitOfWork _unitOfWork;

        public BusLineStopService(IBusLineStopRepo busLineStopRepo, IUnitOfWork unitOfWork)
        {
            _busLineStopRepo = busLineStopRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<BusLineStopResponse> SaveAsync(BusLineStop busLineStop)
        {
            try
            {
                await _busLineStopRepo.AddAsync(busLineStop);
                await _unitOfWork.CompleteAsync();

                return new BusLineStopResponse(busLineStop);
            }
            catch (Exception ex)
            {
                return new BusLineStopResponse($"An error occurred when saving the bus line stop: {ex.Message}");
            }
        }
    }
}