using future_1_.Data;
using future_1_.Models;
using Microsoft.AspNetCore.Hosting;
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
    public class TransportationEntitiesController : Controller
    {

        FutureDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public TransportationEntitiesController(FutureDbContext db ,IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult AllTransportationEntities()
        {
            return View(_db.transportationEntities.Include(x=>x.Region));
        }

        public IActionResult Add()
        {
            ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "EnglishName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(/*[Bind("ImageId,Title,ImageFile")]*/ TransportationEntity transportationEntity)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(transportationEntity.LogoFile.FileName);
                string extension = Path.GetExtension(transportationEntity.LogoFile.FileName);
                transportationEntity.LogoName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
         
                using (var fileStream = new FileStream(path, FileMode.Create))
            {
              await   transportationEntity.LogoFile.CopyToAsync(fileStream);
            }
                //Insert record
                transportationEntity.CreationDate = DateTime.Now;
                _db.transportationEntities.Add(transportationEntity);
                await _db.SaveChangesAsync(); 
                return RedirectToAction("AllTransportationEntities");
            }
            ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "EnglishName");

            return View(transportationEntity);
        }




        //[HttpPost]
        //public IActionResult Add(TransportationEntity transportationEntity)
        //{
        //    if (ModelState.IsValid)
        //    {
               
        //        _db.transportationEntities.Add(transportationEntity);
        //        _db.SaveChanges();
        //        return RedirectToAction("AllTransportationEntities");
        //    }
        //    ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "ArabicName");
        //    return View();
        //}

        public IActionResult Delete(int ?id)
        {
            if(id ==null) return RedirectToAction("AllTransportationEntities");

            var data = _db.transportationEntities.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(TransportationEntity TR)
        {
            _db.transportationEntities.Remove(TR);
            _db.SaveChanges();
            return RedirectToAction("AllTransportationEntities");
        }


        public IActionResult Edit(int ?id)
        {
            if (id == null) return RedirectToAction("AllTransportationEntities");
            ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "ArabicName");

            var data = _db.transportationEntities.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TransportationEntity TR)
        {
            if (ModelState.IsValid)
            {
                _db.transportationEntities.Update(TR);
                _db.SaveChanges();
                return RedirectToAction("AllTransportationEntities");
            }
            ViewBag.MyRegion = new SelectList(_db.regions, "RegionId", "ArabicName");
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("AllTransportationEntities");
            var data = _db.transportationEntities.Find(id);
           
 
            ViewData["Regionss"] = _db.regions.Find(data.RegionId).ArabicName;
            return View(data);
        }



    }
}
