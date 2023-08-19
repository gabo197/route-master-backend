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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryResource>), 200)]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var countries = await countryService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            return resources;
        }
    }
}
