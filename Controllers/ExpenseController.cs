using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var objList = _db.Expenses.Include(x => x.ExpenseType);

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
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Expenses.Add(obj.Expense);
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

            var obj = _db.Expenses.Include(x => x.ExpenseType).FirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = obj,
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        // POST ExpensesController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(ExpenseVM exp)
        {
            var obj = _db.Expenses.Find(exp.Expense.Id);

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

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = obj,
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        // POST: ExpensesController/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ExpenseVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Expenses.Update(obj.Expense);
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
