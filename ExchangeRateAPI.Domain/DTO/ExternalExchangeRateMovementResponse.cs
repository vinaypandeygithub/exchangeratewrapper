using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Domain.DTO
{
    public class ExternalExchangeRateMovementResponse
    { 
        public Motd Motd { get; set; }         
        public bool Success { get; set; } 
        public bool Historical { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
