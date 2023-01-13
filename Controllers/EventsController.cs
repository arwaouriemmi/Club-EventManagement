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
using static System.Net.Mime.MediaTypeNames;

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

            int pageCount = (int)Math.Ceiling((double)unit.Events.GetCount() / 6);

            List<Event> events = unit.Events.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View("Index", events);

        }
        public ViewResult Event(int id)
        {
                Event e = unit.Events.FindEventWithDetails(id);
                return View(e);
        }

        [HttpGet]
        public ViewResult Create()
        {
            Event e = new Event();
            List<string> cat = unit.Events.FindAllCategories();
            cat.Insert(0, "All");
            List<string> club = unit.Events.FindAllClubs();
            List<string> selectedCat = new List<string> { cat[0] };
            List<string> selectedClub = new List<string> { club[0] };
            ViewBag.category = new MultiSelectList(cat, selectedCat);
            ViewBag.club = new MultiSelectList(club, selectedClub);
            return View(e);
        }
        [HttpPost]
        public IActionResult Create(Event e, string club, string category)
        {
            e.Category = category;
            e.Club = unit.Clubs.FindByCondition(c => c.Name == club).FirstOrDefault();

            if (e == null) return RedirectToAction("Create");
            else
            {
                try
                {
                    unit.Events.Create(e);
                    unit.Complete();
                    TempData["success"] = "Event has been created successfully";
                }
                catch (Exception) { TempData["error"] = "An error has occured"; }
                return RedirectToAction("Event", new { id = e.Id });
            }

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Event e = unit.Events.FindEventWithDetails(id);
            if (e == null) return RedirectToAction("Create");
            List<string> cat = unit.Events.FindAllCategories();
            cat.Insert(0, "All");
            List<string> club = unit.Events.FindAllClubs();
            club.Insert(0, "All");
            List<string> selectedCat = new List<string> { e.Category };
            List<string> selectedClub = new List<string> { e.Club.Name };
            ViewBag.category = new MultiSelectList(cat, selectedCat);
            ViewBag.club = new MultiSelectList(club, selectedClub);
            return View(e);
        }
        [HttpPost]
        public IActionResult Update(Event e, string club, string category)
        {
            e.Category = category;
            e.Club = unit.Clubs.FindByCondition(c => c.Name == club).FirstOrDefault();

            Event c = unit.Events.Find(e.Id);
            if (c == null) return RedirectToAction("Update");
            else
            {
                try
                {
                    unit.Events.Update(c, e);
                    unit.Complete();
                    TempData["success"] = "Event has been updated";
                }
                catch (Exception j) { TempData["error"] = j.Message; }
                return RedirectToAction("Event", new { id = c.Id });
            }

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
            DateTime.TryParseExact(createdFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime from);
            DateTime.TryParseExact(createdTo, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime to);

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
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

    }
}
