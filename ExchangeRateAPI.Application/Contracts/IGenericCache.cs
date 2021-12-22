using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Application.Contracts
{
    public interface IGenericCache
    {
        public Task<string> AddToCache(string key,string value);
        public Task<string> GetFromCache(string key);
    }
}
