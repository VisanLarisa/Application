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
        private IRepository<Make> _makeRepository;

        public ModelController(ApplicationDbContext context, IRepository<Model> repository, IRepository<Make> repositoryMake)
        {
            _dbContext = context;
            _modelRepository = repository;
            _makeRepository = repositoryMake;
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
                List<Make> makes =(List<Make>) _makeRepository.GetAll();
                Make make = makes.Find(m => m.BrandName == model.Make.BrandName);
                model.Make = make;
                //nu se face conexiunea intre model si make;

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

