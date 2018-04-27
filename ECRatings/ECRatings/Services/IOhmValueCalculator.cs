using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Models
{
    public interface IOhmValueCalculator
    {
        double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
