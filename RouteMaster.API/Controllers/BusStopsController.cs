﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Extensions;
using RouteMaster.API.Resources;
using RouteMaster.API.Services;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopsController : ControllerBase
    {
        private readonly IBusStopService busStopService;
        private readonly IMapper mapper;

        public BusStopsController(IBusStopService busStopService, IMapper mapper)
        {
            this.busStopService = busStopService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BusStopResource>), 200)]
        public async Task<IEnumerable<BusStopResource>> GetAllAsync()
        {
            var busStops = await busStopService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<BusStop>, IEnumerable<BusStopResource>>(busStops);
            return resources;
        }

        [HttpGet("{id}/BusLine")]
        [ProducesResponseType(typeof(BusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<BusStopResource>> GetByBusLineIdAsync(int id)
        {
            var busStops = await busStopService.GetByBusLineIdAsync(id);
            var resources = mapper
                 .Map<IEnumerable<BusStop>, IEnumerable<BusStopResource>>(busStops);
            return resources;
        }
    }
}