using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeRateAPI.Domain.Models;
using ExchangeRateAPI.CommonFunctions;
using ExchangeRateAPI.Domain.DTO;
using Microsoft.Extensions.Caching.Memory;
using ExchangeRateAPI.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ExchangeRateAPI.Repositories
{
    public class ForexExchangeRepositoryRedis:IForexExchangeRepository
    {
        private readonly HttpClient _client;
        private readonly IDistributedCache _redisCache;

        public ForexExchangeRepositoryRedis(HttpClient client, IDistributedCache cache)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task<ExchangeRateMovementResponse> GetExchangeRateMovementRequest(ExchangeRateMovementRequest exchangeRateMovementRequest)
        {
            List<ExchangeRateData> exchangeRateData = new List<ExchangeRateData>();
            foreach (var date in exchangeRateMovementRequest.DatesToAnalyse)
            {
                var cacheKey = $"/{date.Year}-{date.Month}-{date.Day}?base={exchangeRateMovementRequest.SourceCurrency}&symbols={exchangeRateMovementRequest.TargetCurrency}";
                var cachedexchangeRateDataString =await _redisCache.GetStringAsync(cacheKey);
                var cachedexchangeRateData = JsonConvert.DeserializeObject<ExchangeRateData>(cachedexchangeRateDataString);
                if (cachedexchangeRateData != null) {
                    exchangeRateData.Add(cachedexchangeRateData);
                    continue;
                }
                var response = await _client.GetAsync($"/{date.Year}-{date.Month}-{date.Day}?base={exchangeRateMovementRequest.SourceCurrency}&symbols={exchangeRateMovementRequest.TargetCurrency}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var exchangeRateAPICall = await response.ReadContentAs<ExternalExchangeRateMovementResponse>();
                    if (!exchangeRateAPICall.Success)
                    {
                        throw new Exception("External system was not able to process request, please check parameters");
                    }
                    if (exchangeRateAPICall.Rates.Count == 1)
                    {
                        exchangeRateData.Add(new ExchangeRateData() { BaseCurrency = exchangeRateMovementRequest.SourceCurrency, ConvertedCurrency = exchangeRateMovementRequest.TargetCurrency, Date = date, ExchangeRate = exchangeRateAPICall.Rates[exchangeRateMovementRequest.TargetCurrency] });
                        await _redisCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(new ExchangeRateData() { BaseCurrency = exchangeRateMovementRequest.SourceCurrency, ConvertedCurrency = exchangeRateMovementRequest.TargetCurrency, Date = date, ExchangeRate = exchangeRateAPICall.Rates[exchangeRateMovementRequest.TargetCurrency] }) );
                    }

                }
                else
                {
                    throw new Exception("Could not fetch data from external system");
                }

            }
            ExchangeRateMovementResponse result = new ExchangeRateMovementResponse();
            var maxRateRecord = exchangeRateData.OrderByDescending(x=>x.ExchangeRate).First();
            var minRateRecord = exchangeRateData.OrderBy(x => x.ExchangeRate).First();
            var average = exchangeRateData.Average(x => x.ExchangeRate);
            result.AverageRate = average;
            result.MinimumReached = minRateRecord.ExchangeRate;
            result.MinumumReachedOnDate = minRateRecord.Date;
            result.MaximumReached = maxRateRecord.ExchangeRate;
            result.MaximumReachedOnDate = maxRateRecord.Date;
            return result;
             
        }
    }
}
