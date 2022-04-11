using Application.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class ModelController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ModelController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var models = _dbContext.Makes.ToList();
            return View(models);
        }
    }
}
