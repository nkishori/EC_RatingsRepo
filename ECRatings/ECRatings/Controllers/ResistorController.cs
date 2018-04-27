using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ECRatings.Models;
using ECRatings.Services;

namespace ECRatings.Controllers
{
    public class ResistorController : Controller
    {
        public static string BandAColor, BandBColor, BandCColor, BandDColor;

        private readonly IResistorBandRepository _resistorbandRepository;
        private readonly OhmsCalculatorService _ohmsCalculatorService;

        public ResistorController(IResistorBandRepository resistorbandRepository)
        {
            _resistorbandRepository = resistorbandRepository;
            _ohmsCalculatorService = new OhmsCalculatorService(_resistorbandRepository);
        }

        public IActionResult RatingsCalculator()
        {
            BandAColor = BandBColor = BandCColor = BandDColor = _resistorbandRepository.DefaultBandColor;
            return View(_resistorbandRepository.ResistorBands);
        }

        public JsonResult OhmsCalculator(string id)
        {
            string oldbtnId = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    return null;

                string[] bandId = id.Split('.');

                if (bandId.Length > 0)
                {
                    switch (bandId[1])
                    {
                        case "1":
                            if (_ohmsCalculatorService.IsValidBandABColor(bandId[0]))
                            {
                                oldbtnId = BandAColor + "." + bandId[1];
                                BandAColor = bandId[0];
                            }
                            break;

                        case "2":
                            if (_ohmsCalculatorService.IsValidBandABColor(bandId[0]))
                            {
                                oldbtnId = BandBColor + "." + bandId[1];
                                BandBColor = bandId[0];
                            }
                            break;

                        case "3":
                            if (_ohmsCalculatorService.IsValidBandCColor(bandId[0]))
                            {
                                oldbtnId = BandCColor + "." + bandId[1];
                                BandCColor = bandId[0];
                            }
                            break;

                        case "4":
                            if (_ohmsCalculatorService.IsValidBandDColor(bandId[0]))
                            {
                                oldbtnId = BandDColor + "." + bandId[1];
                                BandDColor = bandId[0];
                            }
                            break;
                    }
                }

                double ohms = _ohmsCalculatorService.CalculateOhmValue(BandAColor, BandBColor, BandCColor, BandDColor);
                return Json(new { ohms = ohms.ToString() + " Ω ", bandAColor = BandAColor, bandBColor = BandBColor, bandCColor = BandCColor, bandDColor = BandDColor, oldId = oldbtnId, selectedId = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}