﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IPaymentTransactionRepo
    {
        Task AddAsync(PaymentTransaction transaction);
    }
}