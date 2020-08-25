using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuakeModeler.Controllers
{
    public class LatLngController : Controller
    {
        public IActionResult Index()
        {
          return View();
        }
        [HttpGet("Coords")]
        public IActionResult Index(string apiKey, string placeName)
        {
          string[] latLng = LatLng.GetLatLng(apiKey, placeName);
          return RedirectToAction("","Quakes");
        }
    }
}