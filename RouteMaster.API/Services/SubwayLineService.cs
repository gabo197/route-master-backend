using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class SubwayLineService : ISubwayLineService
    {
        private readonly ISubwayLineRepo subwayLineRepo;
        private readonly IUnitOfWork unitOfWork;

        public SubwayLineService(ISubwayLineRepo subwayLineRepo, IUnitOfWork unitOfWork)
        {
            this.subwayLineRepo = subwayLineRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SubwayLineResponse> DeleteAsync(int id)
        {
            var existingSubwayLine = await subwayLineRepo.FindByIdAsync(id);

            if (existingSubwayLine == null)
                return new SubwayLineResponse("SubwayLine not found");

            try
            {
                subwayLineRepo.Remove(existingSubwayLine);
                await unitOfWork.CompleteAsync();

                return new SubwayLineResponse(existingSubwayLine);
            }
            catch (Exception ex)
            {
                return new SubwayLineResponse($"An error ocurred while deleting the subwayLine: {ex.Message}");
            }
        }

        public async Task<SubwayLineResponse> GetByIdAsync(int id)
        {
            var existingSubwayLine = await subwayLineRepo.FindByIdAsync(id);

            if (existingSubwayLine == null)
                return new SubwayLineResponse("SubwayLine not found");
            return new SubwayLineResponse(existingSubwayLine);
        }

        public async Task<IEnumerable<SubwayLine>> ListAsync()
        {
            return await subwayLineRepo.ListAsync();
        }

        public async Task<SubwayLineResponse> SaveAsync(SubwayLine subwayLine)
        {
            try
            {
                await subwayLineRepo.AddAsync(subwayLine);
                await unitOfWork.CompleteAsync();

                return new SubwayLineResponse(subwayLine);
            }
            catch (Exception ex)
            {
                return new SubwayLineResponse($"An error ocurred while saving the subwayLine: {ex.Message}");
            }
        }

        public async Task<SubwayLineResponse> UpdateAsync(int id, SubwayLine subwayLine)
        {
            var existingSubwayLine = await subwayLineRepo.FindByIdAsync(id);

            if (existingSubwayLine == null)
                return new SubwayLineResponse("Bus Line not found");

            existingSubwayLine.Code = subwayLine.Code;
            existingSubwayLine.FirstStop = subwayLine.FirstStop;
            existingSubwayLine.LastStop = subwayLine.LastStop;
            existingSubwayLine.Alias = subwayLine.Alias;
            existingSubwayLine.Color = subwayLine.Color;

            try
            {
                subwayLineRepo.Update(existingSubwayLine);
                await unitOfWork.CompleteAsync();

                return new SubwayLineResponse(existingSubwayLine);
            }
            catch (Exception ex)
            {
                return new SubwayLineResponse($"An error ocurred while updating the subwayLine: {ex.Message}");
            }
        }
    }
}
