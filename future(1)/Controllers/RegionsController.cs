using future_1_.Data;
using future_1_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace future_1_.Controllers
{
    public class RegionsController : Controller
    {

        private FutureDbContext _db;

        public RegionsController(FutureDbContext db)
        {
            _db = db;
        }




        [HttpGet]
        public IActionResult AllRegions()
        {
            return View(_db.regions);
        }


        //[HttpPost]
        //public FileResult ExporttoExcel(string HtmlTable)
        //{
        //    return File(Encoding.ASCII.GetBytes(HtmlTable), "application/vnd.ms-excel", "htmltable.xls");
        //}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Add(Region reg)
        {
            if (ModelState.IsValid == false) { return RedirectToAction("Add"); }

            reg.CreationDate = DateTime.Now;
            _db.regions.Add(reg);
            _db.SaveChanges();
            return RedirectToAction("AllRegions");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("AllRegions");
            
            var data = _db.regions.Find(id);

            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("AllRegions");

            var data = _db.regions.Find(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Region reg)
        {
            var data = (from Region in _db.regions
                        where Region.RegionId == reg.RegionId
                        select Region).FirstOrDefault();
            _db.regions.Remove(data); //or delete reg dairctly
            _db.SaveChanges();

            return  RedirectToAction("AllRegions");
        }

        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if (id == null) return RedirectToAction("AllRegions");

            var data = _db.regions.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Region reg)
        {
            _db.regions.Update(reg);
            _db.SaveChanges();
            return RedirectToAction("AllRegions");
        }



    }
}
