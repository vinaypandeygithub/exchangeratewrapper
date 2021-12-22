using ExchangeRateAPI.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRateAPI.Application.Contracts;
using ExchangeRateAPI.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ExchangeRateAPI.Infrastructure.Cache
{
    public class AppDomainCache : IGenericCache
    {
        private readonly IMemoryCache _cache;

        public AppDomainCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<string> AddToCache(string key,string value)
        {
            _cache.Set(key, value);
            return value;
        }

        public async Task<string> GetFromCache(string key)
        {
            var cachedObject = _cache.Get<ExchangeRateData>(key);
            return JsonConvert.SerializeObject(cachedObject);
        }
    }
}
