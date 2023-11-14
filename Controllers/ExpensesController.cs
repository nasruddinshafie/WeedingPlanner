using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeedingPlanner.Models;

namespace WeedingPlanner.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly WeedingPlanner.Entity.ApplicationDbContext _context;
        public ExpensesController(WeedingPlanner.Entity.ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Create()
        {
            List<Budget> budgets = new List<Budget>();

            var budget = await _context.Budgets.ToListAsync();

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

                budgets.Add(bud);
            }
            ViewBag.Budgets = budgets;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new WeedingPlanner.Entity.Expenses
                {
                    Name = expenses.Name,
                    Amount = expenses.Amount,
                    BudgetId = expenses.BudgetId,
                });
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Dashboard");
            }

            List<Budget> budgets = new List<Budget>();

            var budget = await _context.Budgets.ToListAsync();

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

                budgets.Add(bud);
            }
            ViewBag.Budgets = budgets;


            return View(expenses);
        }
    }
}
