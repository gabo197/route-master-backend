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
    public class BusLineStopsController : ControllerBase
    {
        private readonly IBusLineStopService busLineStopService;
        private readonly IMapper mapper;
        
        public BusLineStopsController(IBusLineStopService busLineStopService, IMapper mapper)
        {
            this.busLineStopService = busLineStopService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BusLineStopResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBusLineStopResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var busLineStop = mapper.Map<SaveBusLineStopResource, BusLineStop>(resource);
            var result = await busLineStopService.SaveAsync(busLineStop);

            if (!result.Success)
                return BadRequest(result.Message);

            var busLineStopResource = mapper.Map<BusLineStop, BusLineStopResource>(result.Resource);
            return Ok(busLineStopResource);
        }
    }
}