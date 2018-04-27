using System;
using System.Collections.Generic;
using System.Text;

using ECRatings.Services;
using ECRatings.Models;

using Xunit;

namespace ECRatings.Tests.Models
{
    public class OhmValueCalulatorShould
    {
        [TheoryAttribute]
        [InlineData("Red","Yellow","Red","Brown")]
        public void AcceptOhmsValueRYRB(string bandAcolor, string bandBcolor, string bandCcolor, string  bandDcolor)
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            var ohms = OhmsCalculatorService.CalculateOhmValue(bandAcolor, bandBcolor, bandCcolor, bandDcolor);

            //assert
            Assert.Equal(2400, ohms);
        }

        [TheoryAttribute]
        [InlineData("White", "Yellow", "DeepPink", "Brown")]
        public void AcceptOhmsValueWYDB(string bandAcolor, string bandBcolor, string bandCcolor, string bandDcolor)
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            var ohms = OhmsCalculatorService.CalculateOhmValue(bandAcolor, bandBcolor, bandCcolor, bandDcolor);

            //assert
            Assert.Equal(.094, ohms);
        }

        [TheoryAttribute]
        [InlineData("DeepPink", "Yellow", "DeepPink", "Brown")]
        [InlineData("GoldenRod", "Yellow", "Red", "Brown")]
        [InlineData("Silver", "Silver", "Red", "Brown")]
        public void RejectInvalidInput(string bandAcolor, string bandBcolor, string bandCcolor, string bandDcolor)
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            var ohms = OhmsCalculatorService.CalculateOhmValue(bandAcolor, bandBcolor, bandCcolor, bandDcolor);

            //assert
            Assert.Equal(-1, ohms);
        }

    }
}
