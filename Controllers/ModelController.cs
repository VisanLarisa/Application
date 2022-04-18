using Application.Data;
using Application.Models;
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
        private IRepository<Model> _modelRepository;

        public ModelController(ApplicationDbContext context, IRepository<Model> repository)
        {
            _dbContext = context;
            _modelRepository = repository;
        }
        public IActionResult Index()
        {
            //citire
            var models = _dbContext.Models.ToList();
            return View(models);
        }


        [HttpGet]
        public IActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelRepository.Insert(model);
                _modelRepository.Save();
                return RedirectToAction("Index", "Model");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditModel(Guid ModelId)
        {
            Model model = _modelRepository.GetById(ModelId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelRepository.Update(model);
                _modelRepository.Save();
                return RedirectToAction("Index", "Model");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult DeleteModel(Guid ModelId)
        {
            Model model = _modelRepository.GetById(ModelId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid ModelId)
        {
            _modelRepository.Delete(ModelId);
            _modelRepository.Save();
            return RedirectToAction("Index", "Model");
        }
    }
}

