using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCloud.Web.Models.Calculations
{
    public class BodyMassIndexData
    {
        public double Weight { get; set; }
        public int BodyType { get; set; }
        public double Height { get; set; }

        public double GetBodyTypeMultiplier()
        {
            if (BodyType == 0)
            {
                return 0.9;
            }
            else if (BodyType == 1)
            {
                return 1.1;
            }
            else
            {
                return 1;
            }
        }
    }
}
