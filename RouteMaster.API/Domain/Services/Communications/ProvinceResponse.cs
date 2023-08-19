﻿using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class ProvinceResponse : BaseResponse<Province>
    {
        public ProvinceResponse(Province resource) : base(resource)
        {
        }

        public ProvinceResponse(string message) : base(message)
        {
        }
    }
}
