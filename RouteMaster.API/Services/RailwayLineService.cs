using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class RailwayLineService : IRailwayLineService
    {
        private readonly IRailwayLineRepo railwayLineRepo;
        private readonly IUnitOfWork unitOfWork;

        public RailwayLineService(IRailwayLineRepo railwayLineRepo, IUnitOfWork unitOfWork)
        {
            this.railwayLineRepo = railwayLineRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<RailwayLineResponse> DeleteAsync(int id)
        {
            var existingRailwayLine = await railwayLineRepo.FindByIdAsync(id);

            if (existingRailwayLine == null)
                return new RailwayLineResponse("RailwayLine not found");

            try
            {
                railwayLineRepo.Remove(existingRailwayLine);
                await unitOfWork.CompleteAsync();

                return new RailwayLineResponse(existingRailwayLine);
            }
            catch (Exception ex)
            {
                return new RailwayLineResponse($"An error ocurred while deleting the railwayLine: {ex.Message}");
            }
        }

        public async Task<RailwayLineResponse> GetByIdAsync(int id)
        {
            var existingRailwayLine = await railwayLineRepo.FindByIdAsync(id);

            if (existingRailwayLine == null)
                return new RailwayLineResponse("RailwayLine not found");
            return new RailwayLineResponse(existingRailwayLine);
        }

        public async Task<IEnumerable<RailwayLine>> ListAsync()
        {
            return await railwayLineRepo.ListAsync();
        }

        public async Task<RailwayLineResponse> SaveAsync(RailwayLine railwayLine)
        {
            try
            {
                await railwayLineRepo.AddAsync(railwayLine);
                await unitOfWork.CompleteAsync();

                return new RailwayLineResponse(railwayLine);
            }
            catch (Exception ex)
            {
                return new RailwayLineResponse($"An error ocurred while saving the railwayLine: {ex.Message}");
            }
        }

        public async Task<RailwayLineResponse> UpdateAsync(int id, RailwayLine railwayLine)
        {
            var existingRailwayLine = await railwayLineRepo.FindByIdAsync(id);

            if (existingRailwayLine == null)
                return new RailwayLineResponse("Bus Line not found");

            existingRailwayLine.Code = railwayLine.Code;
            existingRailwayLine.FirstStop = railwayLine.FirstStop;
            existingRailwayLine.LastStop = railwayLine.LastStop;
            existingRailwayLine.Alias = railwayLine.Alias;
            existingRailwayLine.Color = railwayLine.Color;

            try
            {
                railwayLineRepo.Update(existingRailwayLine);
                await unitOfWork.CompleteAsync();

                return new RailwayLineResponse(existingRailwayLine);
            }
            catch (Exception ex)
            {
                return new RailwayLineResponse($"An error ocurred while updating the railwayLine: {ex.Message}");
            }
        }
    }
}
