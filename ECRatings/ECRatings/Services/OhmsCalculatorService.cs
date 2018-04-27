using ECRatings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECRatings.Services
{
    public class OhmsCalculatorService : IOhmValueCalculator
    {
        private readonly IResistorBandRepository _resistorbandRepository;

        public OhmsCalculatorService(IResistorBandRepository resistorbandRepository)
        {
            _resistorbandRepository = resistorbandRepository;
        }
        public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            ResistorBand resistorBandA, resistorBandB, resistorBandC;
            double Rating = -1;

            try
            {
                if (IsValid(bandAColor, bandBColor, bandCColor, bandDColor))
                {
                    resistorBandA = _resistorbandRepository.GetResistorBandByColor(bandAColor);
                    resistorBandB = _resistorbandRepository.GetResistorBandByColor(bandBColor);
                    resistorBandC = _resistorbandRepository.GetResistorBandByColor(bandCColor);

                    Rating = ((resistorBandA.SignificantFigures1 * 10) + (resistorBandB.SignificantFigures2)) * resistorBandC.Multiplier;
                }
            }
            catch
            {
                return Rating;
            }
            return Rating;
        }
        public bool IsValid(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                if (string.IsNullOrEmpty(bandAColor) || string.IsNullOrEmpty(bandBColor) || string.IsNullOrEmpty(bandCColor) || string.IsNullOrEmpty(bandCColor))
                return false;

                if (!IsValidBandABColor(bandAColor) || !IsValidBandABColor(bandBColor) || !IsValidBandCColor(bandCColor) || !IsValidBandDColor(bandDColor))
                    return false;

            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool IsValidBandABColor(string bandABColor)
        {
            List<string> bandColors;
            try
            {
                bandColors = _resistorbandRepository.GetBandAColors();
                if (bandColors == null || !bandColors.Contains(bandABColor))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool IsValidBandCColor(string bandCColor)
        {
            List<string> bandColors;
            try
            {
                bandColors = _resistorbandRepository.GetBandCColors();
                if (bandColors == null || !bandColors.Contains(bandCColor))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool IsValidBandDColor(string bandDColor)
        {
            List<string> bandColors;
            try
            {
                bandColors = _resistorbandRepository.GetBandDColors();
                if (bandColors == null || !bandColors.Contains(bandDColor))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
