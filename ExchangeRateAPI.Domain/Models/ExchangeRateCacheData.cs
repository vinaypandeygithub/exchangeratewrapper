using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Domain.Models
{
    public class ExchangeRateData
    {
        public DateTime Date { get; set; }
        public string BaseCurrency { get; set; }
        public string ConvertedCurrency { get; set; }
        public double ExchangeRate { get; set; }
    }
}
