using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            _db = db;
        }
        // GET: ExpensesController
        public ActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            return View(objList);
        }

        // GET: ExpensesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpensesController/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Expenses.Add(obj);
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

            var obj = _db.Expenses.Find(id);

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
            var obj = _db.Expenses.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
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

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: ExpensesController/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Expense obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Expenses.Update(obj);
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
