using future_1_.Data;
using future_1_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace future_1_.Controllers
{
    public class SchoolsController : Controller
    {
        public FutureDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SchoolsController(FutureDbContext db , IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult AllSchools()
        {
            return View(_db.schools.Include(x=>x.Region));
        }

        public IActionResult Add()
        {        
            ViewBag.MyRegions = new SelectList(_db.regions, "RegionId", "EnglishName");
            ViewBag.tr= JsonConvert.SerializeObject(_db.transportationEntities);

            return View();
        } 
       



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(School school)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(school.LogoFile.FileName);
                string extension = Path.GetExtension(school.LogoFile.FileName);
                school.LogoName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await school.LogoFile.CopyToAsync(fileStream);
                }
                //Insert record
                school.CreationDate = DateTime.Now;
                _db.schools.Add(school);


                //foreach (var item in items)
                //{
                //    var rel = new TransportationEntityAndSchoolRel()
                //    {
                //        SchoolId = school.SchoolId,

                //      //  TransportationEntityId = item
                //    };
                //    _db.TRS_Rel.Add(rel);
                //}
                           
                _db.SaveChanges();
                return RedirectToAction("AllSchools");
            }

             ViewBag.MyRegions = new SelectList(_db.regions, "RegionId", "EnglishName");
            ViewBag.tr = JsonConvert.SerializeObject(_db.transportationEntities);
            return View();
        }


        public IActionResult Delete(int ?id)
        {
            if (id == null) return RedirectToAction("AllSchools");
            else
            {
                var data = _db.schools.Find(id);
                return View(data);
            }
            
        }

        [HttpPost]
        public IActionResult Delete(School school)
        {
            _db.schools.Remove(school);
            _db.SaveChanges();
            return RedirectToAction("AllSchools");
        }

        public IActionResult Edit(int ?id)
        {
            if (id == null) return RedirectToAction("AllSchools");
            else
            {
                ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "ArabicName");

                var data = _db.schools.Find(id);
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                _db.schools.Update(school);
                _db.SaveChanges();
                return RedirectToAction("AllSchools");
            }
            ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "ArabicName");

            return View();
        }
        public IActionResult Details(int ?id)
        {
            if (id == null) return RedirectToAction("AllSchools");

            //  ViewData["Regions"] = _db.regions;
            var data = _db.schools.Find(id);
            var data2 = _db.regions.Find(data.RegionId).ArabicName;  //1
            // ViewBag.Message =data2;    //2
            //ViewData["Message"] = data2; //3
            //TempData["Message"] = data2; //4
            return View(data);

        }

        [HttpPost]
        public async Task<ActionResult> wwww(List<string> items /*, string newParam*/)
        {
           // Task.WaitAll();
            await Task.Delay(5000);
            var lastObjId = _db.schools.OrderByDescending(e => e.SchoolId).FirstOrDefault(); ;
            var r = _db.schools.Count()-1;

            foreach (var item in items)
            {
                var rel = new TransportationEntityAndSchoolRel()
                { 
                    SchoolId = lastObjId.SchoolId,

                    TransportationEntityId =int.Parse(item)
                };
                _db.TRS_Rel.Add(rel);
            }
           // for(var i = 0; i < items.Count; i++) { }
                _db.SaveChanges();
            
            return RedirectToAction("AllSchools");
        }

  
    }
}
