using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _dbContext;
        public AppointmentController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var appointments = _dbContext.Makes.ToList();
            return View(appointments);
        }
    }
}
