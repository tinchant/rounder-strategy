using System;

namespace SampleDomain
{
    public class CRounder : IRoundStrategy
    {
        public decimal Round(decimal numberToRound)
        {
            var proxy = numberToRound.ToString();
            var proxySub = proxy.Substring(proxy.Length - 2);
            var valueToRound = decimal.Parse("0." + proxySub);
            var roundedNumber = Math.Round(valueToRound, 1);
            //transforma devolta em string e substitui no proxy
            //parde pra decimal e retorna
            //Nao completei mas acho q vc consegue seguindo a logica
            return roundedNumber;
        }
    }
}
