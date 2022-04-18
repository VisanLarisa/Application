using Application.Data;
using Application.Models;
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
        private IRepository<Car> _repository;

        public CarController(ApplicationDbContext context, IRepository<Car> repository)
        {
            _dbContext = context;
            _repository = repository;
        }
        public IActionResult Index()
        {
            //citire
            var cars = _dbContext.Cars.ToList();
            return View(cars);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(car);
                _repository.Save();
                return RedirectToAction("Index", "Car");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditCar(Guid id)
        {
            Car car = _repository.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(car);
                _repository.Save();
                return RedirectToAction("Index", "Car");
            }
            else
            {
                return View(car);
            }
        }

        [HttpGet]
        public IActionResult DeleteCar(Guid id)
        {
            Car car = _repository.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index", "Car");
        }
    }
}
