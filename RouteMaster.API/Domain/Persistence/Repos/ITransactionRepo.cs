﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ITransactionRepo
    {
        Task<IEnumerable<Transaction>> ListByWalletIdAsync(int walletId);
    }
}