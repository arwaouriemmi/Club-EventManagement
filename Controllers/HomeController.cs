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
        private UnitOfWork unit = new UnitOfWork(ApplicationContext.Context);
        public ViewResult Index()
        {
            List<Event> events = unit.Events.FindByCondition(e=> DateTime.Compare(e.date, DateTime.Now) > 0).ToList();
            return View(events);
        } 
    }
}
