namespace WeedingPlanner.Entity
{
    public class Expenses
    {
       public int Id { get; set; }

        public string? Name { get; set; }

        public decimal? Amount { get; set; }

        public int BudgetId { get; set; }
    }
}
