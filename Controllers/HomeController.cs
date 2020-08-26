using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;

namespace QuakeModeler.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")] 
        public ActionResult Index()
        {
        return View();
        }
    }
}
