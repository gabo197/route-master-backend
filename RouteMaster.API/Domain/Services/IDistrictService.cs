﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> ListAsync();
    }
}
