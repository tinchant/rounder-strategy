using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDomain
{
    public class RounderOptionRepository
    {
        public IEnumerable<RounderOption> Get() {
            var random = new Random();
            var options =  random.Next(1, 6);

            switch (options)
            {
                case 1:
                    yield return RounderOption.A;
                    break;
                case 2:
                    yield return RounderOption.B;
                    break;
                case 3:
                    yield return RounderOption.C;
                    break;
                case 4:
                    yield return RounderOption.A;
                    yield return RounderOption.C;
                    break;
                case 5:
                    yield return RounderOption.B;
                    yield return RounderOption.C;
                    break;
                case 6:
                    yield return RounderOption.A;
                    yield return RounderOption.B;
                    yield return RounderOption.C;
                    break;
                default:
                    break;
            }
        }
    }
}
