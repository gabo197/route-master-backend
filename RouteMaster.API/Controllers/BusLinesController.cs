using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Extensions;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusLinesController : ControllerBase
    {
        private readonly IBusLineService busLineService;
        private readonly IMapper mapper;

        public BusLinesController(IBusLineService busLineService, IMapper mapper)
        {
            this.busLineService = busLineService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BusLineResource>), 200)]
        public async Task<IEnumerable<BusLineResource>> GetAllAsync()
        {
            var busLines = await busLineService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<BusLine>, IEnumerable<BusLineResource>>(busLines);
            return resources;
        }

        [HttpGet("stop/{stopId}")]
        [ProducesResponseType(typeof(IEnumerable<BusLineResource>), 200)]
        public async Task<IEnumerable<BusLineResource>> GetByStopIdAsync(int stopId)
        {
            var busLines = await busLineService.ListByStopIdAsync(stopId);
            var resources = mapper
                .Map<IEnumerable<BusLine>, IEnumerable<BusLineResource>>(busLines);
            return resources;
        }

        [HttpGet("favorites/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<BusLineResource>), 200)]
        public async Task<IEnumerable<BusLineResource>> GetFavoriteBusLinesByUserId(int userId)
        {
            var busLines = await busLineService.ListFavoriteBusLinesByUserId(userId);
            var resources = mapper
                .Map<IEnumerable<BusLine>, IEnumerable<BusLineResource>>(busLines);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await busLineService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var busLineResource = mapper.Map<BusLine, BusLineResource>(result.Resource);
            return Ok(busLineResource);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(BusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBusLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var busLine = mapper.Map<SaveBusLineResource, BusLine>(resource);
            var result = await busLineService.SaveAsync(busLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var busLineResource = mapper.Map<BusLine, BusLineResource>(result.Resource);
            return Ok(busLineResource);
        }

        [HttpPost("favorites")]
        [ProducesResponseType(typeof(PassengerFavoriteBusLineResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostFavoriteBusLineForUserAsync([FromBody] SavePassengerFavoriteBusLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var passengerFavoriteBusLine = mapper.Map<SavePassengerFavoriteBusLineResource, PassengerFavoriteBusLine>(resource);
            var result = await busLineService.SaveFavoriteBusLineForUserAsync(passengerFavoriteBusLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var passengerFavoriteBusLineResource = mapper.Map<PassengerFavoriteBusLine, PassengerFavoriteBusLineResource>(result.Resource);
            return Ok(passengerFavoriteBusLineResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBusLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var busLine = mapper.Map<SaveBusLineResource, BusLine>(resource);
            var result = await busLineService.UpdateAsync(id, busLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var busLineResource = mapper.Map<BusLine, BusLineResource>(result.Resource);
            return Ok(busLineResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await busLineService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var busLineResource = mapper.Map<BusLine, BusLineResource>(result.Resource);
            return Ok(busLineResource);
        }

        [HttpDelete("favorites/{userId}/{busLineId}")]
        [ProducesResponseType(typeof(PassengerFavoriteBusLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteFavoriteBusLineForUserAsync(int userId, int busLineId)
        {
            var result = await busLineService.DeleteFavoriteBusLineForUserAsync(userId, busLineId);

            if (!result.Success)
                return BadRequest(result.Message);

            var passengerFavoriteBusLineResource = mapper.Map<PassengerFavoriteBusLine, PassengerFavoriteBusLineResource>(result.Resource);
            return Ok(passengerFavoriteBusLineResource);
        }
    }
}
