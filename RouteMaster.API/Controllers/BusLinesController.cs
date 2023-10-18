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
    }
}
