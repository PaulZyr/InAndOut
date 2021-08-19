using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseTypeController(AppDbContext db)
        {
            _db = db;
        }

        // GET: ExpensesController
        public ActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;

            return View(objList);
        }

        // GET: ExpensesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseType obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.ExpenseTypes.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }

        // GET ExpensesController/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST ExpensesController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var obj = _db.ExpenseTypes.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET ExpensesController/Update
        public ActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: ExpensesController/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ExpenseType obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ExpenseTypes.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }
    }
}
