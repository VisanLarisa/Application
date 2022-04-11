using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class MakeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MakeController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var makes = _dbContext.Makes.ToList();
            return View(makes);
        }
    }
}
