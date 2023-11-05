using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class BusLineService : IBusLineService
    {
        private readonly IBusLineRepo busLineRepo;
        private readonly IUnitOfWork unitOfWork;

        public BusLineService(IBusLineRepo busLineRepo, IUnitOfWork unitOfWork)
        {
            this.busLineRepo = busLineRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BusLineResponse> DeleteAsync(int id)
        {
            var existingBusLine = await busLineRepo.FindByIdAsync(id);

            if (existingBusLine == null)
                return new BusLineResponse("BusLine not found");

            try
            {
                busLineRepo.Remove(existingBusLine);
                await unitOfWork.CompleteAsync();

                return new BusLineResponse(existingBusLine);
            }
            catch (Exception ex)
            {
                return new BusLineResponse($"An error ocurred while deleting the busLine: {ex.Message}");
            }
        }

        public async Task<BusLineResponse> GetByIdAsync(int id)
        {
            var existingBusLine = await busLineRepo.FindByIdAsync(id);

            if (existingBusLine == null)
                return new BusLineResponse("BusLine not found");
            return new BusLineResponse(existingBusLine);
        }

        public async Task<IEnumerable<BusLine>> ListAsync()
        {
            return await busLineRepo.ListAsync();
        }

        public async Task<BusLineResponse> SaveAsync(BusLine busLine)
        {
            try
            {
                await busLineRepo.AddAsync(busLine);
                await unitOfWork.CompleteAsync();

                return new BusLineResponse(busLine);
            }
            catch (Exception ex)
            {
                return new BusLineResponse($"An error ocurred while saving the busLine: {ex.Message}");
            }
        }

        public async Task<BusLineResponse> UpdateAsync(int id, BusLine busLine)
        {
            var existingBusLine = await busLineRepo.FindByIdAsync(id);

            if (existingBusLine == null)
                return new BusLineResponse("Bus Line not found");

            existingBusLine.Code = busLine.Code;
            existingBusLine.FirstStop = busLine.FirstStop;
            existingBusLine.LastStop = busLine.LastStop;
            existingBusLine.Alias = busLine.Alias;
            existingBusLine.Color = busLine.Color;
            existingBusLine.OldCode = busLine.OldCode;
            existingBusLine.Logo = busLine.Logo;

            try
            {
                busLineRepo.Update(existingBusLine);
                await unitOfWork.CompleteAsync();

                return new BusLineResponse(existingBusLine);
            }
            catch (Exception ex)
            {
                return new BusLineResponse($"An error ocurred while updating the busLine: {ex.Message}");
            }
        }
    }
}
