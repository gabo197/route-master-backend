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
    public class TripDetailsController : ControllerBase
    {
        private readonly ITripDetailService tripDetailService;
        private readonly IMapper mapper;

        public TripDetailsController(ITripDetailService tripDetailService, IMapper mapper)
        {
            this.tripDetailService = tripDetailService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TripDetailResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTripDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tripDetail = mapper.Map<SaveTripDetailResource, TripDetail>(resource);
            var result = await tripDetailService.SaveAsync(tripDetail);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripDetailResource = mapper.Map<TripDetail, TripDetailResource>(result.Resource);
            return Ok(tripDetailResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TripDetailResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTripDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tripDetail = mapper.Map<SaveTripDetailResource, TripDetail>(resource);
            var result = await tripDetailService.UpdateAsync(id, tripDetail);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripDetailResource = mapper.Map<TripDetail, TripDetailResource>(result.Resource);
            return Ok(tripDetailResource);
        }
    }
}
