using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class InterventionController : Controller
    {
        private ApplicationDbContext _dbContext;
        public InterventionController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var interventions = _dbContext.Makes.ToList();
            return View(interventions);
        }
    }
}
