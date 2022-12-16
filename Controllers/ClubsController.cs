using FrameworksProject.Data.Infrastructure;
using FrameworksProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

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

            int pageCount = (int)Math.Ceiling((double)unit.Clubs.getCount() / 6);

            List<Club> clubs = unit.Clubs.FindRange((page.Value - 1) * 6, 6).ToList();
            ViewBag.page = page;
            ViewBag.pageCount = pageCount;
            return View("Index", clubs);

        }
        
        public ViewResult Club(int id)
        {
            Club e = unit.Clubs.Find(id); 
            return View(e);
        }
        [HttpGet]
        public ViewResult CreateClub()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult CreateClub(string name, string description, string website, int creationYear, string logo)
        {
            
            Club e = new Club(name,description,website,creationYear,logo);
            try
            {
                unit.Clubs.Create(e);
                unit.Complete();
                TempData["success"] = "Club has been created";
            }
            catch (Exception j) { TempData["error"] = j.Message; }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult UpdateClub(int id )
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult UpdateClub(int id, string name, string description, string website, int creationYear, string logo,string president,string hr)
        {

      
            Club e = unit.Clubs.Find(id);
            if (e == null) return RedirectToAction("UpdateClub");
            else
            {
                e.Name = name;
                e.Description = description;
                e.Website = website;
                e.CreationYear = creationYear;
                e.Logo = logo;
                Member m1 = new Member(president, "president", e);
                Member m2 = new Member(hr, "HR", e);
                e.Members.Add(m1);
                e.Members.Add(m2);  
                try
                {
                    unit.Clubs.Update(e);
                    unit.Complete();
                    TempData["success"] = "Club has been updated";
                }
                catch (Exception j) { TempData["error"] = j.Message; }
                return RedirectToAction("Index");
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

            if ( (from!=0 && (from < 1900 || from > 2022)) || (to != 0 && to < 1900))
            {
                TempData["error"] = "Invalid Year";
                return View("Search");
            }
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
                unit.Clubs.Delete(e);
                unit.Complete();

                TempData["success"] = "Club has been deleted";
            }
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
