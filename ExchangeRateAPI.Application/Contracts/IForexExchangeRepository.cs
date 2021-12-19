using ExchangeRateAPI.Domain.DTO;
using ExchangeRateAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Contracts
{
    public interface IForexExchangeRepository
    {
        Task<ExchangeRateMovementResponse> GetExchangeRateMovementRequest(ExchangeRateMovementRequest exchangeRateMovementRequest);
    }
}
