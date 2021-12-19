using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Domain.DTO
{
    public class ExternalExchangeRateMovementRequest
    {
        public List<DateTime> DatesToAnalyse { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
