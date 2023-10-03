using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService districtService;
        private readonly IMapper mapper;

        public DistrictsController(IDistrictService districtService, IMapper mapper)
        {
            this.districtService = districtService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DistrictResource>), 200)]
        public async Task<IEnumerable<DistrictResource>> GetAllAsync()
        {
            var districts = await districtService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);
            return resources;
        }
    }
}
