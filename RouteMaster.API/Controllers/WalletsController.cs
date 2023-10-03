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
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService walletService;

        private readonly IMapper mapper;

        public WalletsController(IWalletService walletService, IMapper mapper)
        {
            this.walletService = walletService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(WalletResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveWalletResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var wallet = mapper.Map<SaveWalletResource, Wallet>(resource);
            var result = await walletService.SaveAsync(wallet);

            if (!result.Success)
                return BadRequest(result.Message);

            var walletResource = mapper.Map<Wallet, WalletResource>(result.Resource);
            return Ok(walletResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(WalletResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveWalletResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var wallet = mapper.Map<SaveWalletResource, Wallet>(resource);
            var result = await walletService.UpdateAsync(id, wallet);

            if (!result.Success)
                return BadRequest(result.Message);

            var walletResource = mapper.Map<Wallet, WalletResource>(result.Resource);
            return Ok(walletResource);
        }
    }
}