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
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _db;

        public ExpensesController(AppDbContext db)
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
            return View();
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense obj)
        {
            try
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpensesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpensesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpensesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpensesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
