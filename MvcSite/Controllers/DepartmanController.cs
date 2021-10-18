using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSite.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcSite.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var dvalues = c.Departmanlars.ToList();
            return View(dvalues);
        }
        [HttpGet]
        public IActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniDepartman(Departmanlar dvalue)
        {
            c.Departmanlars.Add(dvalue);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanSil(int id)
        {
            var dvalue = c.Departmanlars.Find(id);
            c.Departmanlars.Remove(dvalue);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanGetir(int id)
        {
            var dvalue = c.Departmanlars.Find(id);
            return View("DepartmanGetir", dvalue);
        }
        public IActionResult DepartmanGuncelle(Departmanlar dvalue)
        {
            var dep = c.Departmanlars.Find(dvalue.ID);
            dep.DepartmanAdi = dvalue.DepartmanAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanDetay(int id)
        {
            List<Personel> dgr = c.Personels.Where(x => x.DepartmanlarID == id).Include(x => x.Departmanlar).ToList();
            string dadi = c.Departmanlars.Where(x => x.ID == id).Select(y => y.DepartmanAdi).FirstOrDefault();
            ViewBag.baslik = dadi;
            return View(dgr);
        }
    }
}
