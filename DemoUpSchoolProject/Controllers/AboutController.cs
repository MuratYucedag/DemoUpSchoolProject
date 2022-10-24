using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class AboutController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        
        [Authorize]
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout p)
        {
            db.TblAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutID);
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
/*
 hata kodları (401 403 404 500 503)
 */