﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeedingPlanner.Models;

namespace WeedingPlanner.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WeedingPlanner.Entity.ApplicationDbContext _context;
        public DashboardController(WeedingPlanner.Entity.ApplicationDbContext context) 
        {
            _context = context;
        }
        // GET: DashboardController
        public async Task<ActionResult> Index()
        {

            List<Budget> budgets = new List<Budget>();
            List<Expenses> expenses = new List<Expenses>();


            var budget = await _context.Budgets.Include(x => x.Expenses).ToListAsync();

            foreach (var item in budget)
            {
                var bud = new Budget
                {
                    Name = item.Name,
                    Description = item.Description,
                    Amount = item.Amount,
                    Balance = item.Balance,
                    Id = item.Id,

                };

                if (item.Expenses?.Count > 0)
                {
                    foreach (var expense in item.Expenses)
                    {
                        var exp = new Expenses
                        {
                            Amount = expense.Amount,
                            Name = expense.Name,
                            BudgetId = expense.Id,
                        };

                        expenses.Add(exp);
                    }

                    bud.Expenses = expenses;

                }

                budgets.Add(bud);
            }

            return View(budgets);
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
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

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
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
