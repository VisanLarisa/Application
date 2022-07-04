using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _dbContext = context;
            _logger = logger;
        }

        public IActionResult Index()    //returneaza View 
        {
            //adaugare
           // Make make = new Make() { BrandName = "Dacia", OriginCountry = "Romania" };
            //_dbContext.Makes.Add(make);
            //_dbContext.SaveChanges();
            //citire
            //var makes=_dbContext.Makes.ToList();
            //stergere
            //Make toDelete = makes.FirstOrDefault();
            //if(toDelete!=null)
            //{
            //    _dbContext.Makes.Remove(toDelete);
            //    _dbContext.SaveChanges();
            //}
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
