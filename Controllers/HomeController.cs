using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FrameworksProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        public ViewResult Index()
        {
            List<Event> events = unit.Events.FindByCondition(e=> DateTime.Compare(e.Date, DateTime.Now) > 0).ToList();
            return View(events);
        } 
    }
}
