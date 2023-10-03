using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerService passengerService;
        private readonly IMapper mapper;

        public PassengersController(IPassengerService passengerService, IMapper mapper)
        {
            this.passengerService = passengerService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PassengerResource>), 200)]
        public async Task<IEnumerable<PassengerResource>> GetAllAsync()
        {
            var passengers = await passengerService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Passenger>, IEnumerable<PassengerResource>>(passengers);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await passengerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var passengerResource = mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengerResource);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SavePassengerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var passenger = mapper.Map<SavePassengerResource, Passenger>(resource);
            var result = await passengerService.SaveAsync(passenger);

            if (!result.Success)
                return BadRequest(result.Message);

            var passengerResource = mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengerResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePassengerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var passenger = mapper.Map<SavePassengerResource, Passenger>(resource);
            var result = await passengerService.UpdateAsync(id, passenger);

            if (!result.Success)
                return BadRequest(result.Message);

            var passengerResource = mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengerResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await passengerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var passengerResource = mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengerResource);
        }
    }
}
