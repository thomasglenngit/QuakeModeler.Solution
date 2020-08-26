using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using System.Globalization;

namespace QuakeModeler.Controllers
{
  public class QuakesController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(string placeName)
    {
      if(string.IsNullOrEmpty(placeName))
      {
        return View();
      }
      LatLng latLng = LatLng.GetLatLng(placeName);
      return RedirectToAction("Details", latLng);
    }
    
    public IActionResult Details(LatLng latLng)
    {
      var allQuakes = Quake.GetQuakes(latLng.UserLat, latLng.UserLng);
      ViewBag.Possibility = Metrics.PossibilityOfQuake(allQuakes);
      ViewBag.AverageMagnitude = Metrics.StrengthOfQuake(allQuakes);
      ViewBag.QuakeCount = allQuakes.Count;
      ViewBag.MaxMag = Metrics.MaxMagnitude(allQuakes);
      ViewBag.UserData = latLng;
      
      return View(allQuakes);
    } 

    public IActionResult History()
    {
      var allQuakes = Quake.GetWorstQuakes();      
      return View(allQuakes);
    }

    public IActionResult Resources()
    {      
      return View();
    }
  }
}