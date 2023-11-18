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
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            this.transactionService = transactionService;
            this.mapper = mapper;
        }

        [HttpGet("wallet/{walletId}")]
        [ProducesResponseType(typeof(IEnumerable<TransactionResource>), 200)]
        public async Task<IEnumerable<TransactionResource>> GetByWalletIdAsync(int walletId)
        {
            var transactions = await transactionService.ListByWalletIdAsync(walletId);
            var resources = mapper
                .Map<IEnumerable<Transaction>, IEnumerable<TransactionResource>>(transactions);
            return resources;
        }
    }
}