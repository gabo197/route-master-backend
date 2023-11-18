using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Extensions;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeTransactionsController : ControllerBase
    {
        private readonly IRechargeTransactionService rechargeTransactionService;
        private readonly IMapper mapper;

        public RechargeTransactionsController(IRechargeTransactionService rechargeTransactionService, IMapper mapper)
        {
            this.rechargeTransactionService = rechargeTransactionService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRechargeTransactionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rechargeTransaction = mapper.Map<SaveRechargeTransactionResource, RechargeTransaction>(resource);
            var result = await rechargeTransactionService.SaveAsync(rechargeTransaction);

            if (!result.Success)
                return BadRequest(result.Message);

            var rechargeTransactionResource = mapper.Map<RechargeTransaction, TransactionResource>(result.Resource);
            return Ok(rechargeTransactionResource);
        }
    }
}