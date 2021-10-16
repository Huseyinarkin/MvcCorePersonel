using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSite.Models;

namespace MvcSite.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var pvalues = c.Personels.ToList();
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
    }
}
