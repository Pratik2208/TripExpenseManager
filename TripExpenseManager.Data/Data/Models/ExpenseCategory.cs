namespace TripExpenseManager.Data.Data.Models
{
    public class ExpenseCategory : Document
    {
        public ExpenseCategory()
        {

        }
        public ExpenseCategory(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
