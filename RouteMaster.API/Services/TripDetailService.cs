using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Persistence.Repos;

namespace RouteMaster.API.Services
{
    public class TripDetailService : ITripDetailService
    {
        private readonly ITripDetailRepo tripDetailRepo;
        private readonly IUnitOfWork unitOfWork;

        public TripDetailService(ITripDetailRepo tripDetailRepo, IUnitOfWork unitOfWork)
        {
            this.tripDetailRepo = tripDetailRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TripDetailResponse> SaveAsync(TripDetail tripDetail)
        {
            try
            {
                await tripDetailRepo.AddAsync(tripDetail);
                await unitOfWork.CompleteAsync();

                return new TripDetailResponse(tripDetail);
            }
            catch (Exception ex)
            {
                return new TripDetailResponse($"An error ocurred while saving the tripDetail: {ex.Message}");
            }
        }

        public async Task<TripDetailResponse> UpdateAsync(int tripDetailId, TripDetail tripDetail)
        {
            var existingTripDetail = await tripDetailRepo.FindById(tripDetailId);

            if (existingTripDetail == null)
                return new TripDetailResponse("TripDetail not found");

            existingTripDetail.TripId = tripDetail.TripId;
            existingTripDetail.VehicleId = tripDetail.VehicleId;
            existingTripDetail.LineId = tripDetail.LineId;
            existingTripDetail.OriginStopId = tripDetail.OriginStopId;
            existingTripDetail.DestinationStopId = tripDetail.DestinationStopId;
            existingTripDetail.Order = tripDetail.Order;

            try
            {
                tripDetailRepo.Update(existingTripDetail);
                await unitOfWork.CompleteAsync();

                return new TripDetailResponse(existingTripDetail);
            }
            catch (Exception ex)
            {
                return new TripDetailResponse($"An error ocurred while updating the tripDetail: {ex.Message}");
            }
        }
    }
}
