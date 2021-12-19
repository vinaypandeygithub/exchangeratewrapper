using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Domain.DTO
{
    public class Motd
    { 
        public string Msg { get; set; } 
        public Uri Url { get; set; }
    }
}
