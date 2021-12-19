using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRateAPI.CommonFunctions
{
   public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return await JsonSerializer.DeserializeAsync<T>(responseStream, options); 
        }
    }
}
