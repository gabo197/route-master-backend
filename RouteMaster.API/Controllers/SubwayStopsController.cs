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
    public class SubwayStopsController : ControllerBase
    {
        private readonly ISubwayStopService subwayStopService;
        private readonly IMapper mapper;
        
        public SubwayStopsController(ISubwayStopService subwayStopService, IMapper mapper)
        {
            this.subwayStopService = subwayStopService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubwayStopResource>), 200)]
        public async Task<IEnumerable<SubwayStopResource>> GetAllAsync()
        {
            var subwayStops = await subwayStopService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<SubwayStop>, IEnumerable<SubwayStopResource>>(subwayStops);
            return resources;
        }
    }
}