using Financeiro.Models;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class SourceController : Controller
    {
       SourceRepository _rep = new SourceRepository();


        public ActionResult Index()
        {
            return View(_rep.GetAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Source sr)
        {
            _rep.Create(sr);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.classification = _rep.GetById(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Source sr)
        {
            _rep.Edit(sr);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            _rep.Delete(id);
            return RedirectToAction("Index");
        }
    }
}