using future_1_.Data;
using future_1_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Controllers
{
    public class FleetsController : Controller
    {
        public FutureDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FleetsController(FutureDbContext db , IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult AllFleets()
        {
            return View(_db.fleets.Include(x=>x.region).Include(c=>c.transportationEntity));
        }
        public IActionResult Add()
        {
            ViewBag.RegionId =new SelectList(_db.regions,"RegionId","ArabicName");
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");
            ViewBag.DriverId = new SelectList(_db.drivers, "DriverId", "Name");
            Console.WriteLine("ss");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Fleet fleet)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    fleet.FrontBus_license_PH = pic(fleet.FrontBus_license_File, fleet.FrontBus_license_PH).Result;
                    fleet.BackBus_license_PH = pic(fleet.BackBus_license_File, fleet.BackBus_license_PH).Result;
                    fleet.AuthorityPermit_PH = pic(fleet.AuthorityPermit_File, fleet.AuthorityPermit_PH).Result;

                    //Insert record
                    fleet.CreationDate = DateTime.Now;
                    _db.fleets.Add(fleet);
                    _db.SaveChanges();
                    return RedirectToAction("AllFleets");
                }
            }
            catch ( Exception ex)
            {
                ModelState.AddModelError("", "The driver have a fleet , choose another one plaese");
            }



            ViewBag.RegionId = new SelectList(_db.regions, "RegionId", "ArabicName");
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");
           
            ViewBag.DriverId = new SelectList(_db.drivers, "DriverId", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<string> pic(IFormFile file, string name)
        {

            //Save image to wwwroot/image
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return name;
        }

        public IActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return RedirectToAction("AllFleets");
            }
            ViewBag.RegionId = new SelectList(_db.regions, "RegionId", "ArabicName");
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");
            ViewBag.DriverId = new SelectList(_db.drivers, "DriverId", "Name");
            var data = _db.fleets.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                _db.fleets.Update(fleet);
                _db.SaveChanges();
                return RedirectToAction("AllFleets");
            }
            ViewBag.RegionId = new SelectList(_db.regions, "RegionId", "ArabicName");
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");
            ViewBag.DriverId = new SelectList(_db.drivers, "DriverId", "Name");
            return View();
        }

        public IActionResult Details(int ?id)
        {
            if (id == null)
            {
                return RedirectToAction("AllFleets");
            }
            var data = _db.fleets.Find(id);
            ViewData["reg"] = _db.regions.Find(data.RegionId).ArabicName;
            ViewData["tr"] = _db.transportationEntities.Find(data.TransportationEntityId).ArabicName;
            ViewData["dr"] = _db.drivers.Find(data.DriverId).Name;

            return View(data);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllFleets");
            }
            var data = _db.fleets.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                _db.fleets.Remove(fleet);
                _db.SaveChanges();
                return RedirectToAction("AllFleets");

            }
            return View();
        }


    }
}
