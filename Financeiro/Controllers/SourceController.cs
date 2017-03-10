using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class SourceController : Controller
    {
       SourceRepository _rep = new SourceRepository();


        public ActionResult Index()
        {
            return View(_rep.getAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Source sr)
        {
            _rep.create(sr);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.classification = _rep.getById(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Source sr)
        {
            _rep.edit(sr);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            _rep.delete(id);
            return RedirectToAction("Index");
        }
    }
}