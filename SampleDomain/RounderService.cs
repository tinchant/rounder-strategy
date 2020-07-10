using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDomain
{
    public class RounderService
    {
        private readonly IEnumerable<IRoundStrategy> roundStrategies;

        public RounderService(IEnumerable<IRoundStrategy> roundStrategies)
        {
            this.roundStrategies = roundStrategies;
        }


        public decimal Round(decimal rawNumber)
        {
            decimal roundedNumber = rawNumber;
            foreach (var roundStrategy in roundStrategies)
            {
                roundedNumber = roundStrategy.Round(roundedNumber);
            }
            return roundedNumber;
        }
    }
}
