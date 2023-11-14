using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using WeedingPlanner.Models;

namespace WeedingPlanner.Controllers
{
    public class BudgetController : Controller
    {
        // GET: BudgetController

        private readonly WeedingPlanner.Entity.ApplicationDbContext _context;
        public BudgetController(WeedingPlanner.Entity.ApplicationDbContext context) { 
            _context = context;
        }

        public async Task <ActionResult> Index()
        {
            List<Budget> budgets = new List<Budget>();
            List<Expenses> expenses = new List<Expenses>();
            

            var budget = await _context.Budgets.Include(x => x.Expenses).ToListAsync();

            foreach(var item in budget)
            {
                var bud = new Budget
                {
                    Name = item.Name,
                    Description = item.Description,
                    Amount = item.Amount,
                    Balance = item.Balance,
                    Id = item.Id,
                   
                };

                if(item.Expenses?.Count > 0)
                {
                    foreach(var expense in item.Expenses)
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

        // GET: BudgetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BudgetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new WeedingPlanner.Entity.Budget
                {
                    Name = budget.Name,
                    Description = budget.Description,
                    Amount = budget.Amount,
                    Balance = budget.Balance,
                });
                await _context.SaveChangesAsync();

                return RedirectToAction("Index" , "Dashboard");
            }


            return View(budget);
        }

        // GET: BudgetController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var oldBudget = await _context.Budgets.FindAsync(id);
            Budget newBudget = new Budget
            {
                Id = id,
                Name = oldBudget.Name,
                Amount = oldBudget.Amount,
                Description = oldBudget.Description,
                Balance = oldBudget.Balance,
            };

            return View(newBudget);
        }

        // POST: BudgetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, Budget editedBudget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBudget = await _context.Budgets.FindAsync(id);
                    newBudget.Name = editedBudget.Name;
                    newBudget.Description = editedBudget.Description;
                    newBudget.Balance = editedBudget.Balance;
                    newBudget.Amount = editedBudget.Amount;

                }
                return RedirectToAction("Index", new { id = editedBudget.Id });
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the product.");

                return View("Error");
            }
        }

        // GET: BudgetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BudgetController/Delete/5
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
