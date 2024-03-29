﻿using Application.Data;
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

    public class DyeController : Controller
    {
        private readonly ILogger<DyeController> _logger;
        private ApplicationDbContext _dbContext;

        public DyeController(ILogger<DyeController> logger, ApplicationDbContext context)
        {
            _dbContext = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
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
