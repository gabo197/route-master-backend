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
    public class RailwayLineStopsController : ControllerBase
    {
        private readonly IRailwayLineStopService railwayLineStopService;
        private readonly IMapper mapper;
        
        public RailwayLineStopsController(IRailwayLineStopService railwayLineStopService, IMapper mapper)
        {
            this.railwayLineStopService = railwayLineStopService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RailwayLineStopResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRailwayLineStopResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var railwayLineStop = mapper.Map<SaveRailwayLineStopResource, RailwayLineStop>(resource);
            var result = await railwayLineStopService.SaveAsync(railwayLineStop);

            if (!result.Success)
                return BadRequest(result.Message);

            var railwayLineStopResource = mapper.Map<RailwayLineStop, RailwayLineStopResource>(result.Resource);
            return Ok(railwayLineStopResource);
        }
    }
}