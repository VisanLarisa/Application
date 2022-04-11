using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class CarInterventionController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CarInterventionController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var carInterventions = _dbContext.Makes.ToList();
            return View(carInterventions);
        }
    }
}
