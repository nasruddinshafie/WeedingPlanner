using System.ComponentModel.DataAnnotations;

namespace WeedingPlanner.Models
{
    public class Budget
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Balance is required.")]
        public decimal? Balance { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal? Amount { get; set; }

        public List<Expenses>? Expenses { get; set; }
    }
}
