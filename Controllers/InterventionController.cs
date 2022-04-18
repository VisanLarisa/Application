using Application.Data;
using Application.Models;
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
        private IRepository<Intervention> _repository;

        public InterventionController(ApplicationDbContext context, IRepository<Intervention> repository)
        {
            _dbContext = context;
            _repository = repository;

        }
        public IActionResult Index()
        {
            //citire
            var interventions = _dbContext.Interventions.ToList();
            return View(interventions);
        }
        [HttpGet]
        public IActionResult AddIntervention()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddIntervention(Intervention intervention)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(intervention);
                _repository.Save();
                return RedirectToAction("Index", "Intervention");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditIntervention(Guid id)
        {
            Intervention intervention = _repository.GetById(id);
            return View(intervention);
        }

        [HttpPost]
        public IActionResult EditIntervention(Intervention intervention)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(intervention);
                _repository.Save();
                return RedirectToAction("Index", "Intervention");
            }
            else
            {
                return View(intervention);
            }
        }

        [HttpGet]
        public IActionResult DeleteIntervention(Guid id)
        {
            Intervention intervention = _repository.GetById(id);
            return View(intervention);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index", "Intervention");
        }
    }
}
