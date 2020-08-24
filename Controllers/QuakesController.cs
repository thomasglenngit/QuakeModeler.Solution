using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuakeModeler.Controllers
{
    public class QuakesController : Controller
    {
        //form for input, no data
        public IActionResult Index()
        {
          return View();
        }
        //model = result of an api call
        //all earthquakes for a given area
        [HttpGet("Filter")]
        public IActionResult Index(string arg1, string string1, int string2, int number2)
        {
          List<Quake> searchObject = new List<Quake> {};
          var allQuakes = Quake.PredictQuakes(string string1, string string2, int number1, int number2);
          for (int i = 0; i < allDreams.Count; i++)
          {
            //search for string1
            if (string1 != null && allQuakes[i].Field.ToLower().Contains(string1.ToLower()))
            {
              searchObject.Add(allQuakes[i]);
            }
            //search for string2
            if (string2 != null && allQuakes[i].Field.ToLower().Contains(string2.ToLower()))
            {
              searchObject.Add(allQuakes[i]);
            }
            //search for number1
            if (number1 != null && allQuakes[i].Field == number1)
            {
              searchObject.Add(allQuakes[i]);
            }
            //search for number2
            if (number2 != null && allQuakes[i].Field == number2)
            {
              searchObject.Add(allQuakes[i]);
            }
          }
          return View(searchObject);
        }

    }
}