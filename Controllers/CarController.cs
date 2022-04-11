using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CarController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var cars = _dbContext.Makes.ToList();
            return View(cars);
        }
    }
}
