using ExchangeRateAPI.Contracts;
using ExchangeRateAPI.Domain.DTO;
using ExchangeRateAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ForeignExchangeController : Controller
    {
        private readonly IForexExchangeRepository _forexExchangeRepository; 

        public ForeignExchangeController(IForexExchangeRepository forexExchangeRepository)
        {
            _forexExchangeRepository = forexExchangeRepository; 
        }

        [HttpPost]
        [Route("GetExchangeRateMovement")]
        public async Task<ExchangeRateMovementResponse> GetExchangeRateMovementRequest(ExchangeRateMovementRequest exchangeRateMovementRequest)
        {
            return await _forexExchangeRepository.GetExchangeRateMovementRequest(exchangeRateMovementRequest);
        }
    }
}
