using Financeiro.Models;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class ClassificationController : Controller
    {
        ClassificationRepository _rep = new ClassificationRepository();

       
        public ActionResult Index()
        {
            return View(_rep.GetAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Classification cl)
        {
                _rep.Create(cl);
                return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.classification= (Classification) _rep.GetById(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Classification cl)
        {
                _rep.Edit(cl);
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
   
                _rep.Delete(id);
                return RedirectToAction("Index");
        }
    }
}
