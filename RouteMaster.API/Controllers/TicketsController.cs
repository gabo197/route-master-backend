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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;

        private readonly IMapper mapper;

        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTicketResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ticket = mapper.Map<SaveTicketResource, Ticket>(resource);
            var result = await ticketService.SaveAsync(ticket);

            if (!result.Success)
                return BadRequest(result.Message);

            var ticketResource = mapper.Map<Ticket, TicketResource>(result.Resource);
            return Ok(ticketResource);
        }

        [HttpGet, Route("GetTicketsByUserIdAsync/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<TicketResource>), 200)]
        public async Task<IEnumerable<TicketResource>> GetTicketsByUserIdAsync(int userId)
        {
            var tickets = await ticketService.ListByUserIdAsync(userId);
            var resources = mapper
                .Map<IEnumerable<Ticket>, IEnumerable<TicketResource>>(tickets);
            return resources;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketResource>), 200)]
        public async Task<IEnumerable<TicketResource>> GetAllAsync()
        {
            var tickets = await ticketService.ListAsync();
            var resources = mapper
                .Map<IEnumerable<Ticket>, IEnumerable<TicketResource>>(tickets);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await ticketService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var ticketResource = mapper.Map<Ticket, TicketResource>(result.Resource);
            return Ok(ticketResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTicketResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ticket = mapper.Map<SaveTicketResource, Ticket>(resource);
            var result = await ticketService.UpdateAsync(id, ticket);

            if (!result.Success)
                return BadRequest(result.Message);

            var ticketResource = mapper.Map<Ticket, TicketResource>(result.Resource);
            return Ok(ticketResource);
        }
    }
}
