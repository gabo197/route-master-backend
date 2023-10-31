using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Persistence.Repos;

namespace RouteMaster.API.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepo tripRepo;
        private readonly IUnitOfWork unitOfWork;

        public TripService(ITripRepo tripRepo, IUnitOfWork unitOfWork)
        {
            this.tripRepo = tripRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Trip>> GetByUserId(int userId)
        {
            return await tripRepo.FindByUserId(userId);
        }

        public async Task<TripResponse> SaveAsync(Trip trip)
        {
            try
            {
                await tripRepo.AddAsync(trip);
                await unitOfWork.CompleteAsync();

                return new TripResponse(trip);
            }
            catch (Exception ex)
            {
                return new TripResponse($"An error ocurred while saving the trip: {ex.Message}");
            }
        }

        public async Task<TripResponse> UpdateAsync(int tripId, Trip trip)
        {
            var existingTrip = await tripRepo.FindById(tripId);

            if (existingTrip == null)
                return new TripResponse("Trip not found");

            existingTrip.EndDate = trip.EndDate;
            existingTrip.TotalPrice = trip.TotalPrice;

            try
            {
                tripRepo.Update(existingTrip);
                await unitOfWork.CompleteAsync();

                return new TripResponse(existingTrip);
            }
            catch (Exception ex)
            {
                return new TripResponse($"An error ocurred while updating the trip: {ex.Message}");
            }   
        }
    }
}
