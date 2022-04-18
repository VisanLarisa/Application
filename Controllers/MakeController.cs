using Application.Data;
using Application.Models;
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
        private IMakeRepository _makeRepository;

        public MakeController(ApplicationDbContext context, IMakeRepository repository)
        {
            _dbContext = context;
            // _makeRepository = new IMakeRepository(context);
            _makeRepository = repository;
        }

    //    public MakeController(IMakeRepository repository)
    //    {
     //       _makeRepository = repository;
      //  }
        public IActionResult Index()
        {
            //citire
            var makes = _dbContext.Makes.ToList();
           // var model = _makeRepository.GetAll();
            return View(makes);
        }

        [HttpGet]
        public IActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMake(Make model)
        {
            if (ModelState.IsValid)
            {
                _makeRepository.Insert(model);
                _makeRepository.Save();
                return RedirectToAction("Index", "Make");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditMake(Guid MakeId)
        {
            Make make = _makeRepository.GetById(MakeId);
            return View(make);
        }

        [HttpPost]
        public IActionResult EditMake(Make make)
        {
            if (ModelState.IsValid)
            {
                _makeRepository.Update(make);
                _makeRepository.Save();
                return RedirectToAction("Index", "Make");
            }
            else
            {
                return View(make);
            }
        }

        [HttpGet]
        public IActionResult DeleteMake(Guid MakeId)
        {
            Make make = _makeRepository.GetById(MakeId);
            return View(make);
        }

        [HttpPost]
        public IActionResult Delete(Guid MakeId)
        {
            _makeRepository.Delete(MakeId);
            _makeRepository.Save();
            return RedirectToAction("Index", "Make");
        }
    }
}
