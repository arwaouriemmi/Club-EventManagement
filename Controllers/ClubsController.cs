using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Transactions;

namespace FrameworksProject.Controllers
{
    public class ClubsController : Controller
    {
        private readonly IUnitOfWork unit = new UnitOfWork();

        public ClubsController(IUnitOfWork @object) => unit = @object;

        public ViewResult Index([FromQuery] int? page)
        {
            if (!page.HasValue)
                page = 1;

            int pageCount = (int)Math.Ceiling((double)unit.Clubs.GetCount() / 6);

            List<Club> clubs = unit.Clubs.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View("Index", clubs);

        }
        
        public ViewResult Club(int id)
        {
            Club e = unit.Clubs.FindCompleteClub(id); 
            return View(e);
        }

        [HttpGet]
        public ViewResult Create()
        {
            Club c = new Club();
            return View(c);
        }
        [HttpPost]
        public RedirectToActionResult Create(Club club, ICollection<string> roles, ICollection<string> names)
        {
            if (club == null) return RedirectToAction("Create");
            else
            {
                try
                {
                    club.Members = unit.Clubs.AddMembers(club, roles, names);
                    unit.Clubs.Create(club);
                    unit.Complete();
                    TempData["success"] = "Club has been created successfully";
                }
                catch (Exception) { TempData["error"] = "An error has occured"; }
                return RedirectToAction("Club", new { id = club.Id });
            }
        }
        [HttpGet]
        public ActionResult Update(int id )
        {

            Club c = unit.Clubs.GetClubWithMembers(id);
            if (c == null) return RedirectToAction("Create");
            return View(c);
        }

        [HttpPost]
        public IActionResult Update(Club club, ICollection<string> ids, ICollection<string> roles, ICollection<string> names )
        {
            Club c = unit.Clubs.GetClubWithMembers(club.Id);
            if (club == null) return RedirectToAction("Update");
            else
            {
                try
                {
                    c = unit.Clubs.UpdateMembers(c, ids, roles, names);
                    unit.Clubs.Update(c, club);
                    unit.Complete();
                    TempData["success"] = "Club has been updated";
                }
                catch (Exception j) { TempData["error"] = j.Message; }
                return RedirectToAction("Club", new { id = c.Id });
            }

        }

        [HttpGet]
        public ViewResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ViewResult Search(string name, string createdFrom, string createdTo)
        {
            int from;
            int to;
            if (createdFrom == "") from = 0;
            else int.TryParse(createdFrom, out from);
            if (createdTo == "") to = 0;
            else int.TryParse(createdTo, out to);

            ViewBag.name = name ?? "";
            ViewBag.from = createdFrom;
            ViewBag.to = createdTo;

            List<Club> clubs = unit.Clubs.SearchByNameOrDate(name, from, to).ToList();
            ViewBag.pageCount = 0;
            ViewBag.page = 0;
            return View("Index", clubs);
        }

        public RedirectToActionResult Delete(int id)
        {
            try
            {
                Club e = unit.Clubs.Find(id);
                unit.Clubs.DeleteAllMembers(e);
                unit.Clubs.DeleteAllEvents(e);
                unit.Clubs.Delete(e);
                unit.Complete();
                TempData["success"] = "Club has been deleted";
            }
            catch (Exception)
            {
                TempData["error"] = "An error has occured. Try again.";
            }
            return RedirectToAction("Index");
        }
    }
}
