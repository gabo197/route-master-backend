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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyResource>), 200)]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await companyService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await companyService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var companyResource = mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await companyService.SaveAsync(company);

            if (!result.Success)
                return BadRequest(result.Message);

            var companyResource = mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await companyService.UpdateAsync(id, company);

            if (!result.Success)
                return BadRequest(result.Message);

            var companyResource = mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await companyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var companyResource = mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }
    }
}
