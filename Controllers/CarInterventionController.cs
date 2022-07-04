using Application.Data;
using Application.Models;
using Application.Models.Base;
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
        private IRepository<CarIntervention> _repository;
        public CarInterventionController(ApplicationDbContext context, IRepository<CarIntervention> repository)
        {
            _dbContext = context;
            _repository = repository;
        }
        public CarInterventionController(ApplicationDbContext context)
        {
            _dbContext = context;
            _repository = new Repository<CarIntervention>(context);
        }
        public IActionResult Index()
        {
            //citire
            var carInterventions = _dbContext.CarInterventions.ToList();
            return View(carInterventions);
        }
        [HttpGet]
        public IActionResult AddCarIntervantion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCarIntervention(CarIntervention carIntervention)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(carIntervention);
                _repository.Save();
                return RedirectToAction("Index", "CarIntervention");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditCarIntervention(Guid id)
        {
            CarIntervention carIntervention = _repository.GetById(id);
            return View(carIntervention);
        }

        [HttpPost]
        public IActionResult EditCarIntervention(CarIntervention carIntervention)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(carIntervention);
                _repository.Save();
                return RedirectToAction("Index", "CarIntervention");
            }
            else
            {
                return View(carIntervention);
            }
        }

        [HttpGet]
        public IActionResult DeleteCarIntervention(Guid id)
        {
            CarIntervention carIntervention = _repository.GetById(id);
            return View(carIntervention);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index", "CarIntervention");
        }
    }
}
