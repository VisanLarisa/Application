using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Application.Models.Base;

/*using System.Web.Mvc;*/

namespace Application.Controllers
{
    public class EventController : Controller
    {
        //private readonly ILogger<EventController> _logger;

        private ApplicationDbContext _dbContext;
        public IRepository<Event> _eventRepository;

        /*        public EventController()
                {
                    _eventRepository = new Repository<Event>(_dbContext);
                }*/
        public EventController(ApplicationDbContext context, IRepository<Event> repository)
        {
            // _logger = logger;
            _dbContext = context;
            _eventRepository = repository;
        }
/*        public EventController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }*/
        public IActionResult Index()
        {
            //citire
            // var events = _dbContext.Events.ToList();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            var events = _dbContext.Events.ToList();
            return View(events);
        }


/*        [HttpGet]
        public ActionResult Index()
        {
            var model = _eventRepository.GetAll();
            return View(model);
        }*/
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(Event eventx)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Insert(eventx);
                _eventRepository.Save();
                return RedirectToAction("Index", "Event");
            }
            return View();
        }


/*        [HttpPost]
        public IActionResult AddEvent()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult EditEvent(Guid Eventid)
        {
            Event eventx = _eventRepository.GetById(Eventid);
            return View(eventx);
        }

        [HttpPost]
        public IActionResult EditEvent(Event eventx)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Update(eventx);
                _eventRepository.Save();
                return RedirectToAction("Index", "Event");
            }
            else
            {
                return View(eventx);
            }
        }

        [HttpGet]
/*        public IActionResult DeleteEvent(Guid Eventid)
        {
            Event eventx = _eventRepository.GetById(Eventid);
            return View(eventx);
        }*/

        [HttpPost]
        public IActionResult Delete(Guid EventId)
        {
            _eventRepository.Delete(EventId);
            _eventRepository.Save();
            return RedirectToAction("Index", "Event");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public System.Web.Mvc.JsonResult GetEvents()
        {

            //using (ApplicationDbContext db=n)
            var events = _dbContext.Events.ToList();
            var result= new System.Web.Mvc.JsonResult { Data = events, JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet };
            return result;
        }

        [HttpPost]
        public System.Web.Mvc.JsonResult SaveEvent(Event e)
        {
            var status = false;
            var stringId = Convert.ToString(e.Id);
                if (stringId!= "00000000-0000-0000-0000-000000000000")
                {
                    //Update the event
                    var v = _dbContext.Events.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                 _dbContext.Events.Add(e);
                //     AddEvent(e);
                }
                _dbContext.SaveChanges();
                status = true;
            
             var result=new System.Web.Mvc.JsonResult { Data = new { status = status } };
             return result;
        }

        [HttpPost]
        public System.Web.Mvc.JsonResult DeleteEvent(Guid eventID)
        {
            var status = false;
                var v = _dbContext.Events.Where(a => a.Id == eventID).FirstOrDefault();
                if (v != null)
                {
                _dbContext.Events.Remove(v);
                _dbContext.SaveChanges();
                    status = true;
                }
            
            return new System.Web.Mvc.JsonResult { Data = new { status = status } };
        }
    }
}
