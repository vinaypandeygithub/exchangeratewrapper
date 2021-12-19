using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Domain.Models
{
    public class ExchangeRateMovementResponse
    {
        public DateTime MaximumReachedOnDate { get; set; }
        public DateTime MinumumReachedOnDate { get; set; }
        public double MaximumReached { get; set; }
        public double MinimumReached { get; set; }
        public double AverageRate{get;set;}
    }
}
