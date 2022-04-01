using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class CarsController : Controller
    {
      /*  public IActionResult Index()
        {
            return View();
        }*/

        public string Index()
        {
            return "This is my <b>default</b> action...";
        }
        public string Welcome()
        {
            return "This is the Cars action method...";
        }
    }
}
