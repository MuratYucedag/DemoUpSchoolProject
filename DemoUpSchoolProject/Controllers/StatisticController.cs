using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            //referansların toplam sayısı
            ViewBag.v1 = db.TblTestimonial.Count();

            //istanbuldaki referans sayısı
            ViewBag.v2 = db.TblTestimonial.Where(x => x.City == "İstanbul").Count();

            //Yazılım Mühendisi Haricindeki kişi sayısı
            ViewBag.v3 = db.TblTestimonial.Where(x => x.Profession != "Yazılım Mühendisi").Count();

            //Şehri Trabzon olan kişinin ismini getiren sorgu
            ViewBag.v4 = db.TblTestimonial.Where(x => x.City == "Trabzon").Select(y => y.NameSurname).FirstOrDefault();

            //referansların ortalama maaşı
            ViewBag.v5 = db.TblTestimonial.Average(x => x.Balance);
            return View();
        }
    }
}