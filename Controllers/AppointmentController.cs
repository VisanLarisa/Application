using Application.Data;
using Application.Models;
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
        private IRepository<Appointment> _repository;
        public AppointmentController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //citire
            var appointments = _dbContext.Appointments.ToList();
            return View(appointments);
        }


        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(appointment);
                _repository.Save();
                return RedirectToAction("Index", "Appointment");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditAppointment(Guid id)
        {
            Appointment appointment = _repository.GetById(id);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult EditAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(appointment);
                _repository.Save();
                return RedirectToAction("Index", "Appointment");
            }
            else
            {
                return View(appointment);
            }
        }

        [HttpGet]
        public IActionResult DeleteAppointment(Guid id)
        {
            Appointment appointment = _repository.GetById(id);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index", "Appointment");
        }
    }
}
