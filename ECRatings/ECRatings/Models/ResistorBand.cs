using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Models
{
    public class ResistorBand
    {
        public string BandID { get; set; }
        public string Color { get; set; }
        public int SignificantFigures1 { get; set; }
        public int SignificantFigures2 { get; set; }
        public double Multiplier { get; set; }
        public double ToleranceInPercentage { get; set; }
    }
}
