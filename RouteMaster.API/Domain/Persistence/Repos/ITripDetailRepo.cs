﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ITripDetailRepo
    {
        Task AddAsync(TripDetail tripDetail);
        Task<TripDetail?> FindById(int tripDetailId);
        void Update(TripDetail tripDetail);
    }
}
