using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using ECRatings.Models;
using ECRatings.Services;

namespace ECRatings.Tests.Models
{
    public class ResistorRatingsServiceTest
    {
        [Fact]
        public void OhmsCalculator()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            var ohms = OhmsCalculatorService.CalculateOhmValue("Red", "Red", "Red", "Red");

            //assert
            Assert.Equal(2200, ohms);
        }

        [Fact]
        public void OhmsCalculator1()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            var ohms = OhmsCalculatorService.CalculateOhmValue("Red", "Yellow", "XXX", "Red");

            //assert
            Assert.Equal(2200, ohms);
        }

        [Fact]
        public void OhmsCalculator2()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            var ohms = OhmsCalculatorService.CalculateOhmValue("Red", "Yellow", "DeepPink", "Red");

            //assert
            Assert.Equal(.024, ohms);
        }

        [Fact]
        public void IsBandColorValid()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);
            bool isValid  = OhmsCalculatorService.IsValid("Red", "Red", "Red", "Red");

            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsBandAColorValid()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            bool isValid = OhmsCalculatorService.IsValidBandABColor("GoldenRod");

            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsBandBColorValid()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            bool isValid = OhmsCalculatorService.IsValidBandABColor("Yellow");

            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsBandCColorValid()
        {
            var mockPieRepository = new ResistorBandRepository();

            ////arrange
            var OhmsCalculatorService = new OhmsCalculatorService(mockPieRepository);

            bool isValid = OhmsCalculatorService.IsValidBandABColor("Grey");

            //assert
            Assert.True(isValid);
        }
    }
}
