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
    public class PaymentTransactionsController : ControllerBase
    {
        private readonly IPaymentTransactionService paymentTransactionService;
        private readonly IMapper mapper;

        public PaymentTransactionsController(IPaymentTransactionService paymentTransactionService, IMapper mapper)
        {
            this.paymentTransactionService = paymentTransactionService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentTransactionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paymentTransaction = mapper.Map<SavePaymentTransactionResource, PaymentTransaction>(resource);
            var result = await paymentTransactionService.SaveAsync(paymentTransaction);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentTransactionResource = mapper.Map<PaymentTransaction, TransactionResource>(result.Resource);
            return Ok(paymentTransactionResource);
        }
    }
}