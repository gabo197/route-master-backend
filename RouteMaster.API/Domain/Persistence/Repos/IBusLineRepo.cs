﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IBusLineRepo
    {
        Task<IEnumerable<BusLine>> ListAsync();
        Task AddAsync(BusLine busLine);
        Task<BusLine?> FindByIdAsync(int id);
        void Update(BusLine busLine);
        void Remove(BusLine busLine);
    }
}
