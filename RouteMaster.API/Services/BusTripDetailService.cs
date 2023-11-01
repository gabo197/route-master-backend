using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Persistence.Repos;

namespace RouteMaster.API.Services
{
    public class BusTripDetailService : IBusTripDetailService
    {
        private readonly IBusTripDetailRepo busTripDetailRepo;
        private readonly IUnitOfWork unitOfWork;

        public BusTripDetailService(IBusTripDetailRepo busTripDetailRepo, IUnitOfWork unitOfWork)
        {
            this.busTripDetailRepo = busTripDetailRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BusTripDetailResponse> SaveAsync(BusTripDetail tripDetail)
        {
            try
            {
                await busTripDetailRepo.AddAsync(tripDetail);
                await unitOfWork.CompleteAsync();

                return new BusTripDetailResponse(tripDetail);
            }
            catch (Exception ex)
            {
                return new BusTripDetailResponse($"An error ocurred while saving the tripDetail: {ex.Message}");
            }
        }

        public async Task<BusTripDetailResponse> UpdateAsync(int tripDetailId, BusTripDetail tripDetail)
        {
            var existingTripDetail = await busTripDetailRepo.FindById(tripDetailId);

            if (existingTripDetail == null)
                return new BusTripDetailResponse("TripDetail not found");

            existingTripDetail.TripId = tripDetail.TripId;
            existingTripDetail.VehicleId = tripDetail.VehicleId;
            existingTripDetail.LineId = tripDetail.LineId;
            existingTripDetail.OriginStopId = tripDetail.OriginStopId;
            existingTripDetail.DestinationStopId = tripDetail.DestinationStopId;
            existingTripDetail.Order = tripDetail.Order;

            try
            {
                busTripDetailRepo.Update(existingTripDetail);
                await unitOfWork.CompleteAsync();

                return new BusTripDetailResponse(existingTripDetail);
            }
            catch (Exception ex)
            {
                return new BusTripDetailResponse($"An error ocurred while updating the tripDetail: {ex.Message}");
            }
        }
    }
}
