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
    public class SubwayLinesController : ControllerBase
    {
        private readonly ISubwayLineService subwayLineService;
        private readonly IMapper mapper;

        public SubwayLinesController(ISubwayLineService subwayLineService, IMapper mapper)
        {
            this.subwayLineService = subwayLineService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubwayLineResource>), 200)]
        public async Task<IEnumerable<SubwayLineResource>> GetAllAsync()
        {
            var subwayLines = await subwayLineService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<SubwayLine>, IEnumerable<SubwayLineResource>>(subwayLines);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await subwayLineService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subwayLineResource = mapper.Map<SubwayLine, SubwayLineResource>(result.Resource);
            return Ok(subwayLineResource);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(SubwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubwayLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subwayLine = mapper.Map<SaveSubwayLineResource, SubwayLine>(resource);
            var result = await subwayLineService.SaveAsync(subwayLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var subwayLineResource = mapper.Map<SubwayLine, SubwayLineResource>(result.Resource);
            return Ok(subwayLineResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SubwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubwayLineResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subwayLine = mapper.Map<SaveSubwayLineResource, SubwayLine>(resource);
            var result = await subwayLineService.UpdateAsync(id, subwayLine);

            if (!result.Success)
                return BadRequest(result.Message);

            var subwayLineResource = mapper.Map<SubwayLine, SubwayLineResource>(result.Resource);
            return Ok(subwayLineResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SubwayLineResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await subwayLineService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var subwayLineResource = mapper.Map<SubwayLine, SubwayLineResource>(result.Resource);
            return Ok(subwayLineResource);
        }
    }
}
