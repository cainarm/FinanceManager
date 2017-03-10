using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.Sources = _SourceRep.getAll();
            try
            {
                if (Request["date"] != null)
                {
                    if (Request["source"] != null && Int32.Parse(Request["source"]) != 0)
                    {
                        return View(_rep.getByDateAndSource(Int32.Parse(Request["source"]), DateTime.Parse(Request["date"])));
                    }
                    else
                    {

                        return View(_rep.getByDate(DateTime.Parse(Request["date"])));
                    }
                }

            }
            catch (Exception e)
            {

            }
           
            return View(_rep.getAll());
        }

        public ActionResult create()
        {
            ViewBag.Classification = _ClassRep.getAll();
            ViewBag.Sources = _SourceRep.getAll();

            return View( );
        }

        [HttpPost]
        public ActionResult create(Expense exp)
        {
           
            _rep.create(exp);
            return RedirectToAction("");
        }

        public ActionResult delete(int id)
        {
            _rep.delete(id);
            return RedirectToAction("");
        }
        public ActionResult edit(int id)
        {
            ViewBag.Classification = _ClassRep.getAll();
            ViewBag.Sources = _SourceRep.getAll();
            ViewBag.item = _rep.getById(id);
            return View();
        }

        [HttpPost]
        public ActionResult edit(Expense exp)
        {
            _rep.edit(exp);
            return RedirectToAction("");
        }
    }
}