using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Extensions;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayStopsController : ControllerBase
    {
        private readonly IRailwayStopService railwayStopService;
        private readonly IMapper mapper;
        
        public RailwayStopsController(IRailwayStopService railwayStopService, IMapper mapper)
        {
            this.railwayStopService = railwayStopService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RailwayStopResource>), 200)]
        public async Task<IEnumerable<RailwayStopResource>> GetAllAsync()
        {
            var railwayStops = await railwayStopService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<RailwayStop>, IEnumerable<RailwayStopResource>>(railwayStops);
            return resources;
        }
    }
}