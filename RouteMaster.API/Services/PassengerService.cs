using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Util;

namespace RouteMaster.API.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepo passengerRepo;
        private readonly IUnitOfWork unitOfWork;

        public PassengerService(IPassengerRepo passengerRepo, IUnitOfWork unitOfWork)
        {
            this.passengerRepo = passengerRepo;
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<PassengerResponse> DeleteAsync(int id)
        {
            var existingPassenger = await passengerRepo.FindById(id);

            if (existingPassenger == null)
                return new PassengerResponse("Passenger not found");

            try
            {
                passengerRepo.Remove(existingPassenger);
                await unitOfWork.CompleteAsync();

                return new PassengerResponse(existingPassenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error ocurred while deleting the passenger: {ex.Message}");
            }
        }

        public async Task<PassengerResponse> GetByIdAsync(int id)
        {
            var existingPassenger = await passengerRepo.FindById(id);

            if (existingPassenger == null)
                return new PassengerResponse("Passenger not found");
            return new PassengerResponse(existingPassenger);
        }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            return await passengerRepo.ListAsync();
        }

        public async Task<PassengerResponse> SaveAsync(Passenger passenger)
        {
            try
            {
                await passengerRepo.AddAsync(passenger);
                await unitOfWork.CompleteAsync();

                return new PassengerResponse(passenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error ocurred while saving the passenger: {ex.Message}");
            }
        }

        public async Task<PassengerResponse> UpdateAsync(int id, Passenger passenger)
        {
            var existingPassenger = await passengerRepo.FindById(id);

            if (existingPassenger == null)
                return new PassengerResponse("Passenger not found");

            existingPassenger.FirstName = passenger.FirstName;
            existingPassenger.MiddleName = passenger.MiddleName;
            existingPassenger.LastName = passenger.LastName;
            existingPassenger.LastName2 = passenger.LastName2;
            existingPassenger.PhoneNumber = passenger.PhoneNumber;
            existingPassenger.PaymentMethodId = passenger.PaymentMethodId;
            existingPassenger.Wallet.Balance = WalletBalanceEncryptor.Encrypt(existingPassenger.Wallet.Balance);

            try
            {
                passengerRepo.Update(existingPassenger);
                await unitOfWork.CompleteAsync();

                return new PassengerResponse(existingPassenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error ocurred while updating the passenger: {ex.Message}");
            }
        }
    }
}
