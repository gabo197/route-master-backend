using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService provinceService;
        private readonly IMapper mapper;

        public ProvincesController(IProvinceService provinceService, IMapper mapper)
        {
            this.provinceService = provinceService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProvinceResource>), 200)]
        public async Task<IEnumerable<ProvinceResource>> GetAllAsync()
        {
            var provinces = await provinceService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Province>, IEnumerable<ProvinceResource>>(provinces);
            return resources;
        }
    }
}
