using System.ComponentModel.DataAnnotations;

namespace WeedingPlanner.Models
{
    public class Expenses
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal? Amount { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        public int BudgetId { get; set; }
    }
}
