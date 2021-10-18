using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<SelectListItem> degerler = (from x in c.Departmanlars.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAdi,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel pvalue)
        {
            var per = c.Departmanlars.Where(x => x.ID == pvalue.Departmanlar.ID).FirstOrDefault();
            pvalue.Departmanlar = per;
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
