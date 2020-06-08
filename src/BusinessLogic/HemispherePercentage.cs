using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class HemispherePercentage
    {
        public double RightPercentage { get; set; }
        public double LeftPercentage { get; set; }
        public override string ToString()
        {
            return $"jobb agyfélteke: {RightPercentage.ToString("0.00")}%, bal agyfélteke: {LeftPercentage.ToString("0.00")}%";
        }
    }
}
