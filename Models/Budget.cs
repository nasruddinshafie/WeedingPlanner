namespace WeedingPlanner.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }

        public decimal? Balance { get; set; }

        public decimal? Amount { get; set;}

        public List<Expenses>? Expenses { get; set; }
    }
}
