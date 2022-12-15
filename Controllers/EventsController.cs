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
        private readonly IUnitOfWork unit = new UnitOfWork();

        public EventsController(IUnitOfWork @object) => unit = @object;

        public ViewResult Index([FromQuery] int? page)
        {
            if (!page.HasValue)
                page = 1;

            int pageCount = (int)Math.Ceiling((double)unit.Events.getCount() / 6);

            List<Event> events = unit.Events.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View("Index", events);

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

            ViewBag.category = new MultiSelectList(cat, selectedCat);
            ViewBag.club = new MultiSelectList(club, selectedClub);
            return View("Search");
        }

        [HttpPost]
        public IActionResult Search(string name, string category, string club, string createdFrom, string createdTo)
        {
            DateTime.TryParseExact(createdFrom, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime from);
            DateTime.TryParseExact(createdTo, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime to);

            if ((from.Year==0001 && createdFrom != null) || (to.Year == 0001 && createdTo != null))
            {
                TempData["error"] = "Invalid Year";
                return RedirectToAction("Search");
            }
            ViewBag.name = name ?? "";
            ViewBag.category = category ?? "";
            ViewBag.club = club ?? "";
            ViewBag.from = createdFrom; ViewBag.to = createdTo;
            ViewBag.page = 0; ViewBag.pageCount = 0;

            List<Event> events = unit.Events.Search(name, category, club, from, to).ToList();
            return View("Index", events);
        }

        public RedirectToActionResult Delete(int id)
        {
            try 
            {
                Event e = unit.Events.Find(id);
                unit.Events.Delete(e);
                unit.Complete();
                
                TempData["success"] = "Event has been deleted";
            } catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }

    }
}
