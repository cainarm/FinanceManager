using Financeiro.Models;
using System;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class ExpenseController : Controller
    {
        ClassificationRepository _ClassRep = new ClassificationRepository();
        SourceRepository _SourceRep = new SourceRepository();
        ExpenseRepository _rep = new ExpenseRepository();
       
        public ActionResult Index()
        {
            ViewBag.Sources = _SourceRep.GetAll();
            try
            {
                if (Request["date"] != null)
                {
                    if (Request["source"] != null && Int32.Parse(Request["source"]) != 0)
                    {
                        return View(_rep.GetByDateAndSource(Int32.Parse(Request["source"]), DateTime.Parse(Request["date"])));
                    }
                    else
                    {

                        return View(_rep.GetByDate(DateTime.Parse(Request["date"])));
                    }
                }

            }
            catch (Exception e)
            {

            }
           
            return View(_rep.GetAll());
        }

        public ActionResult create()
        {
            ViewBag.Classification = _ClassRep.GetAll();
            ViewBag.Sources = _SourceRep.GetAll();

            return View( );
        }

        [HttpPost]
        public ActionResult create(Expense exp)
        {
           
            _rep.Create(exp);
            return RedirectToAction("");
        }

        public ActionResult delete(int id)
        {
            _rep.Delete(id);
            return RedirectToAction("");
        }
        public ActionResult edit(int id)
        {
            ViewBag.Classification = _ClassRep.GetAll();
            ViewBag.Sources = _SourceRep.GetAll();
            ViewBag.item = _rep.GetById(id);
            return View();
        }

        [HttpPost]
        public ActionResult edit(Expense exp)
        {
            _rep.Edit(exp);
            return RedirectToAction("");
        }
    }
}