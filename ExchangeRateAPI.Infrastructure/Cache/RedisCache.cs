using ExchangeRateAPI.Application.Contracts;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ExchangeRateAPI.Infrastructure.Cache
{
    public class RedisCache : IGenericCache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<string> AddToCache(string key,string value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject( value));
            return JsonConvert.SerializeObject(value);
        }

        public async Task<string>  GetFromCache(string key)
        {
            var cacheString =await _cache.GetStringAsync(key);
            return cacheString;
        }
    }
}
