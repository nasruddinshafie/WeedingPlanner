using Microsoft.AspNetCore.Mvc;

namespace WeedingPlanner.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
