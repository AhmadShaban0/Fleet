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
    public class DriversController : Controller
    {
        public FutureDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DriversController(FutureDbContext db , IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult AllDrivers()
        {
            return View(_db.drivers.Include(x=>x.trEntity));
        }


        [HttpGet]
        public IActionResult Add()
        {
        

                ViewBag.TransportationEntityId=new SelectList(_db.transportationEntities,"TransportationEntityId","ArabicName");
            return View();
        } 


        //[HttpPost]
        //public IActionResult Add(Driver driver)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        driver.CreationDate = DateTime.Now;
        //        _db.drivers.Add(driver);
        //        _db.SaveChanges();
        //        return RedirectToAction("AllDrivers");
        //    }

        //    ViewBag.TransportationEntityId= new SelectList(_db.transportationEntities, "TransportationId", "ArabicName");

        //    return View();
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Driver driver)
        {
            if (ModelState.IsValid)
            {
                
                driver.IDPhoto=pic(driver.IdPhoto_File, driver.IDPhoto).Result; 
                driver.DriverLicense_PH=pic(driver.DriverLicense_File,driver.DriverLicense_PH).Result; 
                driver.DiseaseFreeCert_PH= pic(driver.DiseaseFreeCert_File,driver.DiseaseFreeCert_PH).Result; 
                driver.NonConvictionCert_PH= pic(driver.NonConvictionCert_File,driver.NonConvictionCert_PH).Result;
                driver.SecurityPermit_PH= pic(driver.SecurityPermit_File,driver.SecurityPermit_PH).Result; 
                driver.PersonalPhoto=pic(driver.PersonalPhoto_File,driver.PersonalPhoto).Result; 
                
                //Insert record
                driver.CreationDate = DateTime.Now;
                _db.drivers.Add(driver);
                _db.SaveChanges();
                return RedirectToAction("AllDrivers");
            }

            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationId", "ArabicName");

            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<string> pic (IFormFile file, string name) 
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
        public IActionResult Edit(int ? id)
        {
            if (id == null) return RedirectToAction("AllDrivers");

            var data = _db.drivers.Find(id);
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");

            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                driver.CreationDate = DateTime.Now;
                _db.drivers.Update(driver);
                _db.SaveChanges();
                return RedirectToAction("AllDrivers");
            }
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");

            return View();
        }


        public IActionResult Details(int ?id)
        {
            if (id == null) return RedirectToAction("AllDrivers");

            var data = _db.drivers.Find(id);
        //    ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");

            ViewData["tr"] = _db.transportationEntities.Find(data.TransportationEntityId).ArabicName;

            var xx = (from item in _db.fleets
                     where item.DriverId==id
                     select item).FirstOrDefault();
            return View(data);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("AllDrivers");

            var data = _db.drivers.Find(id);
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");

            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _db.drivers.Remove(driver);
                _db.SaveChanges();
                return RedirectToAction("AllDrivers");
            }
            ViewBag.TransportationEntityId = new SelectList(_db.transportationEntities, "TransportationEntityId", "ArabicName");

            return View();
        }

        public IActionResult NewPassword(int? id)
        {
            if (id == null) return RedirectToAction("AllDrivers");

            var data = _db.drivers.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult NewPassword(Driver driver)
        {
            if (ModelState.IsValid)
            {
               _db.drivers.Update(driver);
     
               _db.SaveChanges();
                return RedirectToAction("AllDrivers");
            }
            return View();
        }
    }
}
