using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _ratingRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RatingService(IRatingRepo ratingRepo, IUnitOfWork unitOfWork)
        {
            _ratingRepo = ratingRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<RatingResponse> SaveAsync(Rating rating)
        {
            try
            {
                await _ratingRepo.AddAsync(rating);
                await _unitOfWork.CompleteAsync();

                return new RatingResponse(rating);
            }
            catch (Exception ex)
            {
                return new RatingResponse($"An error occurred when saving the rating: {ex.Message}");
            }
        }
    }
}