using System;
using System.Collections.Generic;
using System.Text;

using ECRatings.Models;

using Moq;

namespace ECRatings.Tests.Models
{
    public class ReposistoryMocks
    {
        //public static Mock<IResistorBandRepository> GetResistorRepository()
        //{
        //    var bands = new List<ResistorBand>
        //    {
        //        new ResistorBand() { Color = "Black",  SignificantFigures1 = 0,  SignificantFigures2 = 0, Multiplier = 1, ToleranceInPercentage = -1 },
        //        new ResistorBand() { Color = "Brown", SignificantFigures1 = 1, SignificantFigures2 = 1, Multiplier = 10, ToleranceInPercentage = 1 },
        //        new ResistorBand() { Color = "Red", SignificantFigures1 = 2, SignificantFigures2 = 2, Multiplier = 100, ToleranceInPercentage = 2 },
        //        new ResistorBand() { Color = "Orange", SignificantFigures1 = 3, SignificantFigures2 = 3, Multiplier = 1000, ToleranceInPercentage = -1 },
        //        new ResistorBand() { Color = "Yellow", SignificantFigures1 = 4, SignificantFigures2 = 4, Multiplier = 10000, ToleranceInPercentage = -1 },
        //        new ResistorBand() { Color = "YellowGreen", SignificantFigures1 = 5, SignificantFigures2 = 5, Multiplier = 100000, ToleranceInPercentage = .5 },
        //        new ResistorBand() { Color = "CornflowerBlue", SignificantFigures1 = 6, SignificantFigures2 = 6, Multiplier = 1000000, ToleranceInPercentage = .25 },
        //        new ResistorBand() { Color = "DarkViolet", SignificantFigures1 = 7, SignificantFigures2 = 7, Multiplier = 10000000, ToleranceInPercentage = .10 },
        //        new ResistorBand() { Color = "Grey", SignificantFigures1 = 8, SignificantFigures2 = 8, Multiplier = -1, ToleranceInPercentage = 0.05 },
        //        new ResistorBand() { Color = "White", SignificantFigures1 = 9, SignificantFigures2 = 9, Multiplier = -1, ToleranceInPercentage = -1 },
        //        new ResistorBand() { Color = "GoldenRod", SignificantFigures1 = -1, SignificantFigures2 = 10, Multiplier = .1, ToleranceInPercentage = 5 },
        //        new ResistorBand() { Color = "Silver", SignificantFigures1 = -1, SignificantFigures2 = 11, Multiplier = .01, ToleranceInPercentage = 10 }

        //};

        //    var resistorBandRepository = new Mock<IResistorBandRepository>();
        //    resistorBandRepository.Setup(repo => repo.ResistorBands).Returns(bands);
        //    resistorBandRepository.Setup(repo => repo.GetResistorBandByColor(It.IsAny<string>())).Returns(bands[2]);
        //    return resistorBandRepository;
        //}

        public static Mock<ResistorBandRepository> GetResistorRepository()
        {
            var resistorBandRepository = new Mock<ResistorBandRepository>();
            //resistorBandRepository.Setup(repo => repo.ResistorBands).Returns(bands);
            //resistorBandRepository.Setup(repo => repo.GetResistorBandByColor(It.IsAny<string>())).Returns(bands[2]);
            return resistorBandRepository;
        }
    }
}
