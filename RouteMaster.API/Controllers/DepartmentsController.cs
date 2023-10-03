using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentResource>), 200)]
        public async Task<IEnumerable<DepartmentResource>> GetAllAsync()
        {
            var departments = await departmentService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);
            return resources;
        }
    }
}
