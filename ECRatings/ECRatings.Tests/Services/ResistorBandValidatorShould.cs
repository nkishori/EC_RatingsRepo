using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using ECRatings.Models;
using ECRatings.Services;

namespace ECRatings.Tests.Models
{
    public class ResistorBandValidatorShould
    {
        [Theory]
        [InlineData("Black")]
        [InlineData("Brown")]
        [InlineData("Red")]
        [InlineData("Orange")]
        [InlineData("Yellow")]
        [InlineData("YellowGreen")]
        [InlineData("CornflowerBlue")]
        [InlineData("DarkViolet")]
        [InlineData("Grey")]
        [InlineData("White")]
        public void ShouldAcceptBandAColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandABColor(color);

            //assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("GoldenRod")]
        [InlineData("Silver")]
        [InlineData("DeepPink")]
        [InlineData("XXX")]
        public void RejectInvalidBandAColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandABColor(color);

            //assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Black")]
        [InlineData("Brown")]
        [InlineData("Red")]
        [InlineData("Orange")]
        [InlineData("Yellow")]
        [InlineData("YellowGreen")]
        [InlineData("CornflowerBlue")]
        [InlineData("DarkViolet")]
        [InlineData("Grey")]
        [InlineData("White")]
        [InlineData("GoldenRod")]
        [InlineData("Silver")]
        [InlineData("DeepPink")]
        public void ShouldAcceptBandCColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandCColor(color);

            //assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("Pink")]
        [InlineData("Green")]
        [InlineData("XXX")]
        public void RejectInvalidBandCColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandCColor(color);

            //assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Brown")]
        [InlineData("Red")]
        [InlineData("YellowGreen")]
        [InlineData("CornflowerBlue")]
        [InlineData("DarkViolet")]
        [InlineData("Grey")]
        [InlineData("GoldenRod")]
        [InlineData("Silver")]
        public void ShouldAcceptBandDColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandDColor(color);

            //assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("Black")]
        [InlineData("Orange")]
        [InlineData("Yellow")]
        [InlineData("White")]
        [InlineData("DeepPink")]
        public void RejectInvalidBandDColors(string color)
        {
            var mockPieRepository = new ResistorBandRepository();
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            ////arrange
            bool isValid = OhmsCalculatorService.IsValidBandDColor(color);

            //assert
            Assert.False(isValid);
        }

    }
}
