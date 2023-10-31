using AutoMapper;
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
    public class TripsController : ControllerBase
    {
        private readonly ITripService tripService;
        private readonly IMapper mapper;

        public TripsController(ITripService tripService, IMapper mapper)
        {
            this.tripService = tripService;
            this.mapper = mapper;
        }

        [HttpGet("{userId}/users")]
        [ProducesResponseType(typeof(IEnumerable<TripResource>), 200)]
        public async Task<IEnumerable<TripResource>> GetByUserIdAsync(int userId)
        {
            var trips = await tripService.GetByUserId(userId);
            var resources = mapper
                .Map<IEnumerable<Trip>, IEnumerable<TripResource>>(trips);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TripResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTripResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trip = mapper.Map<SaveTripResource, Trip>(resource);
            var result = await tripService.SaveAsync(trip);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripResource = mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TripResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTripResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trip = mapper.Map<SaveTripResource, Trip>(resource);
            var result = await tripService.UpdateAsync(id, trip);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripResource = mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }
    }
}
