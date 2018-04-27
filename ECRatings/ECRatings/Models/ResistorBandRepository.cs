using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Models
{
    public class ResistorBandRepository: IResistorBandRepository
    {
       private readonly List<ResistorBand> _resistorBands;
       public List<ResistorBand> ResistorBands
        {
            get
            {
                return _resistorBands;
            }
        }

        public ResistorBandRepository()
        {
            _resistorBands = new List<ResistorBand>();
            _resistorBands.Add(new ResistorBand() { Color = "Black", SignificantFigures1 = 0, SignificantFigures2 = 0, Multiplier = 1, ToleranceInPercentage = -1 });
            _resistorBands.Add(new ResistorBand() { Color = "Brown", SignificantFigures1 = 1, SignificantFigures2 = 1, Multiplier = 10, ToleranceInPercentage = 1 });
            _resistorBands.Add(new ResistorBand() { Color = "Red", SignificantFigures1 = 2, SignificantFigures2 = 2, Multiplier = 100, ToleranceInPercentage = 2 });
            _resistorBands.Add(new ResistorBand() { Color = "Orange", SignificantFigures1 = 3, SignificantFigures2 = 3, Multiplier = 1000, ToleranceInPercentage = -1 });
            _resistorBands.Add(new ResistorBand() { Color = "Yellow", SignificantFigures1 = 4, SignificantFigures2 = 4, Multiplier = 10000, ToleranceInPercentage = -1 });
            _resistorBands.Add(new ResistorBand() { Color = "YellowGreen", SignificantFigures1 = 5, SignificantFigures2 = 5, Multiplier = 100000, ToleranceInPercentage = .5 });
            _resistorBands.Add(new ResistorBand() { Color = "CornflowerBlue", SignificantFigures1 = 6, SignificantFigures2 = 6, Multiplier = 1000000, ToleranceInPercentage = .25 });
            _resistorBands.Add(new ResistorBand() { Color = "DarkViolet", SignificantFigures1 = 7, SignificantFigures2 = 7, Multiplier = 10000000, ToleranceInPercentage = .10 });
            _resistorBands.Add(new ResistorBand() { Color = "Grey", SignificantFigures1 = 8, SignificantFigures2 = 8, Multiplier = 100000000, ToleranceInPercentage = 0.05 });
            _resistorBands.Add(new ResistorBand() { Color = "White", SignificantFigures1 = 9, SignificantFigures2 = 9, Multiplier = 1000000000, ToleranceInPercentage = -1 });
            _resistorBands.Add(new ResistorBand() { Color = "GoldenRod", SignificantFigures1 = -1, SignificantFigures2 = -1, Multiplier = .1, ToleranceInPercentage = 5 });
            _resistorBands.Add(new ResistorBand() { Color = "Silver", SignificantFigures1 = -1, SignificantFigures2 = -1, Multiplier = .01, ToleranceInPercentage = 10 });
            _resistorBands.Add(new ResistorBand() { Color = "DeepPink", SignificantFigures1 = -1, SignificantFigures2 = -1, Multiplier = .001, ToleranceInPercentage = -1 });

        }
        public ResistorBand GetResistorBandByColor(string BandColor)
        {
            return ResistorBands.Where<ResistorBand>(band => band.Color == BandColor).FirstOrDefault();
        }

        public string DefaultBandColor
        {
            get
            {
                if (ResistorBands.Count > 0)
                    return ResistorBands[1].Color;

                return string.Empty;
            }
        }

        public List<string> GetBandAColors()
        {
            List<string> bandAColors;

            var bandcolors = ResistorBands.Where<ResistorBand>(band => band.SignificantFigures1 != -1).ToList<ResistorBand>();

            bandAColors = new List<string>();
            foreach (ResistorBand b in bandcolors)
            {
                bandAColors.Add(b.Color);
            }

            return bandAColors;
        }

        public List<string> GetBandCColors()
        {
            List<string> bandCColors;

            var bandcolors = ResistorBands.Where<ResistorBand>(band => band.Multiplier != -1).ToList<ResistorBand>();

            bandCColors = new List<string>();
            foreach (ResistorBand b in bandcolors)
            {
                bandCColors.Add(b.Color);
            }

            return bandCColors;
        }

        public List<string> GetBandDColors()
        {
            List<string> bandDColors;

            var bandcolors = ResistorBands.Where<ResistorBand>(band => band.ToleranceInPercentage != -1).ToList<ResistorBand>();

            bandDColors = new List<string>();
            foreach (ResistorBand b in bandcolors)
            {
                bandDColors.Add(b.Color);
            }

            return bandDColors;
        }
    }
}
