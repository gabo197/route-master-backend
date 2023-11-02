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
    public class SubwayLineStopsController : ControllerBase
    {
        private readonly ISubwayLineStopService subwayLineStopService;
        private readonly IMapper mapper;
        
        public SubwayLineStopsController(ISubwayLineStopService subwayLineStopService, IMapper mapper)
        {
            this.subwayLineStopService = subwayLineStopService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SubwayLineStopResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubwayLineStopResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subwayLineStop = mapper.Map<SaveSubwayLineStopResource, SubwayLineStop>(resource);
            var result = await subwayLineStopService.SaveAsync(subwayLineStop);

            if (!result.Success)
                return BadRequest(result.Message);

            var subwayLineStopResource = mapper.Map<SubwayLineStop, SubwayLineStopResource>(result.Resource);
            return Ok(subwayLineStopResource);
        }
    }
}