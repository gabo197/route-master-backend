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
    public class TransferTransactionsController : ControllerBase
    {
        private readonly ITransferTransactionService transferTransactionService;
        private readonly IMapper mapper;

        public TransferTransactionsController(ITransferTransactionService transferTransactionService, IMapper mapper)
        {
            this.transferTransactionService = transferTransactionService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTransferTransactionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var transferTransaction = mapper.Map<SaveTransferTransactionResource, TransferTransaction>(resource);
            var result = await transferTransactionService.SaveAsync(transferTransaction);

            if (!result.Success)
                return BadRequest(result.Message);

            var transferTransactionResource = mapper.Map<TransferTransaction, TransactionResource>(result.Resource);
            return Ok(transferTransactionResource);
        }
    }
}