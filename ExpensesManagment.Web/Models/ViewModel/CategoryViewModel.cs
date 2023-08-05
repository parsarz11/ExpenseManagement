using ExpensesManagment.Web.Data.Entities;

namespace ExpensesManagment.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category> categoryList {  get; set; }
        public List<Expense> ExpensesList { get; set; }
        public Expense expense { get; set; }
    }
}
