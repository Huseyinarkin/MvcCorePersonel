using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSite.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcSite.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var pvalues = c.Personels.Include(x=>x.Departmanlar).ToList();
            return View(pvalues);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel pvalue)
        {
            c.Personels.Add(pvalue);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var pvalue = c.Personels.Find(id);
            c.Personels.Remove(pvalue);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelGetir(int id)
        {
            var pvalue = c.Personels.Find(id);
            return View("PersonelGetir", pvalue);
        }
        public IActionResult PersonelGuncelle(Personel pvalue)
        {
            var pep = c.Personels.Find(pvalue.ID);
            pep.Ad = pvalue.Ad;
            pep.SoyAd = pvalue.SoyAd;
            pep.Sehir = pvalue.Sehir;
            pep.DepartmanlarID = pvalue.DepartmanlarID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
