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
        private readonly IResistorBandRepository _resistorbandRepository;
        private readonly OhmsCalculatorService _ohmsCalculatorService;

        public ResistorController(IResistorBandRepository resistorbandRepository)
        {
            _resistorbandRepository = resistorbandRepository;
            _ohmsCalculatorService = new OhmsCalculatorService(_resistorbandRepository);
        }

        public IActionResult RatingsCalculator()
        {
            return View(_resistorbandRepository.ResistorBands);
        }

        public JsonResult OhmsCalculator(string bandAColor, string bandBColor, string bandCColor, string bandDColor, string selectedbtnId)
        {
            string oldbtnId = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(selectedbtnId))
                    return null;

                string[] selbtnId = selectedbtnId.Split('.');

                if (selbtnId.Length > 0)
                {
                    switch (selbtnId[1])
                    {
                        case "1":
                            if (_ohmsCalculatorService.IsValidBandABColor(selbtnId[0]))
                            {
                                oldbtnId = bandAColor + "." + selbtnId[1];
                                bandAColor = selbtnId[0];
                            }
                            break;

                        case "2":
                            if (_ohmsCalculatorService.IsValidBandABColor(selbtnId[0]))
                            {
                                oldbtnId = bandBColor + "." + selbtnId[1];
                                bandBColor = selbtnId[0];
                            }
                            break;

                        case "3":
                            if (_ohmsCalculatorService.IsValidBandCColor(selbtnId[0]))
                            {
                                oldbtnId = bandCColor + "." + selbtnId[1];
                                bandCColor = selbtnId[0];
                            }
                            break;

                        case "4":
                            if (_ohmsCalculatorService.IsValidBandDColor(selbtnId[0]))
                            {
                                oldbtnId = bandDColor + "." + selbtnId[1];
                                bandDColor = selbtnId[0];
                            }
                            break;
                    }
                }

                double ohms = _ohmsCalculatorService.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
                return Json(new { ohms = ohms.ToString() + " Ω ", bandAColor = bandAColor, bandBColor = bandBColor, bandCColor = bandCColor, bandDColor = bandDColor, oldId = oldbtnId, selectedId = selectedbtnId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}