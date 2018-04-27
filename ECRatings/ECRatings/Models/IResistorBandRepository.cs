using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Models
{
    public interface IResistorBandRepository
    {
        List<ResistorBand> ResistorBands { get; }
        string DefaultBandColor { get; }
        List<string> GetBandAColors();
        List<string> GetBandCColors();
        List<string> GetBandDColors();

        ResistorBand GetResistorBandByColor(string BandColor);
    }
}
