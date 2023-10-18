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
    public class RailwayLinesController : ControllerBase
    {
        private readonly IRailwayLineService railwayLineService;
        private readonly IMapper mapper;

        public RailwayLinesController(IRailwayLineService railwayLineService, IMapper mapper)
        {
            this.railwayLineService = railwayLineService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RailwayLineResource>), 200)]
        public async Task<IEnumerable<RailwayLineResource>> GetAllAsync()
        {
            var railwayLines = await railwayLineService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<RailwayLine>, IEnumerable<RailwayLineResource>>(railwayLines);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RailwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await railwayLineService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var railwayLineResource = mapper.Map<RailwayLine, RailwayLineResource>(result.Resource);
            return Ok(railwayLineResource);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(RailwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRailwayLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var railwayLine = mapper.Map<SaveRailwayLineResource, RailwayLine>(resource);
            var result = await railwayLineService.SaveAsync(railwayLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var railwayLineResource = mapper.Map<RailwayLine, RailwayLineResource>(result.Resource);
            return Ok(railwayLineResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RailwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRailwayLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var railwayLine = mapper.Map<SaveRailwayLineResource, RailwayLine>(resource);
            var result = await railwayLineService.UpdateAsync(id, railwayLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var railwayLineResource = mapper.Map<RailwayLine, RailwayLineResource>(result.Resource);
            return Ok(railwayLineResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RailwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await railwayLineService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var railwayLineResource = mapper.Map<RailwayLine, RailwayLineResource>(result.Resource);
            return Ok(railwayLineResource);
        }
    }
}
