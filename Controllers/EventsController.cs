using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Controllers
{
    public class EventsController : Controller
    {
        private UnitOfWork unit = new UnitOfWork(ApplicationContext.Context);

        public ViewResult Index([FromQuery] int? page)
        {
            if (!page.HasValue)
                page = 1;

            int pageCount = (int)Math.Ceiling((double)unit.Clubs.getCount() / 6);

            List<Event> events = unit.Events.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View(events);

        }

        [HttpGet]
        public ViewResult Search()
        {
            List<string> cat = unit.Events.FindAllCategories();
            cat.Insert(0, "All");
            List<string> club = unit.Events.FindAllClubs();
            club.Insert(0, "All");

            List<string> selectedCat = new List<string> { cat[0] };
            List<string> selectedClub = new List<string> { club[0] };

            ViewBag.error = TempData["error"];
            ViewBag.category = new MultiSelectList(cat, selectedCat);
            ViewBag.club = new MultiSelectList(club, selectedClub);
            return View();
        }

        [HttpPost]
        public IActionResult Search(string name, string category, string club, string createdFrom, string createdTo)
        {
            DateTime from;
            DateTime.TryParseExact(createdFrom, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out from);
            DateTime to;
            DateTime.TryParseExact(createdTo, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out to);

            if (from.Year==0001 && createdFrom != null)
            {
                TempData["error"] = "Invalid Year";
                return RedirectToAction("Search");
            }
            if (to.Year == 0001 && createdTo != null)
            {
                TempData["error"] = "Invalid Year";
                return RedirectToAction("Search");
            }
            ViewBag.name = name!=null ? name: "";
            ViewBag.category = category != null ? category : "";
            ViewBag.club = club != null ? club : "";
            ViewBag.from = createdFrom; ViewBag.to = createdTo;
            ViewBag.page = 0; ViewBag.pageCount = 0;

            List<Event> events = unit.Events.Search(name, category, club, from, to).ToList();
            return View("Index", events);
        }

    }
}
