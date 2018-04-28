using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Models
{
    public interface IOhmValueCalculator
    {
        //Changed the interace to return a double as the muliplier can be .1,.01,.001
        double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
