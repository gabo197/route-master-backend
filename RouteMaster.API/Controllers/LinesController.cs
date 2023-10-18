using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class LinesController : ControllerBase
    {
        private readonly ILineService lineService;
        private readonly IMapper mapper;

        public LinesController(ILineService lineService, IMapper mapper)
        {
            this.lineService = lineService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LineResource>), 200)]
        public async Task<IEnumerable<LineResource>> GetAllAsync()
        {
            var lines = await lineService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Line>, IEnumerable<LineResource>>(lines);
            return resources;
        }
    }
}
