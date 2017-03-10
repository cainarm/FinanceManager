using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class ClassificationController : Controller
    {
        ClassificationRepository _rep = new ClassificationRepository();

       
        public ActionResult Index()
        {
            return View(_rep.getAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Classification cl)
        {
                _rep.create(cl);
                return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.classification= (Classification) _rep.getById(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Classification cl)
        {
                _rep.edit(cl);
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
   
                _rep.delete(id);
                return RedirectToAction("Index");
        }
    }
}
