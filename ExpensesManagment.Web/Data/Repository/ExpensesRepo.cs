using ExpensesManagment.Web.Data.Context;
using ExpensesManagment.Web.Data.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExpensesManagment.Web.Data.Repository
{
    public class ExpensesRepo
    {
        private readonly DatabaseContext _DataBaseContext;
        public ExpensesRepo(DatabaseContext dataBaseContext)
        {
            _DataBaseContext = dataBaseContext;
        }

        public List<Expense> ExpenseListByFk(int CategoryFk)
        {
            var expenseList = _DataBaseContext.Expenses.Where(x=>x.CategoryFK == CategoryFk).ToList();
            return expenseList;
        }

        public List<Expense> ExpenseList()
        {
            return _DataBaseContext.Expenses.ToList();
        }

        public void ExpenseAdd(Expense expense) 
        {
            _DataBaseContext.Expenses.Add(expense);
            _DataBaseContext.SaveChanges();
        }

        public void ExpenseDelete(int id)
        {
            var expensesToRemove = _DataBaseContext.Expenses.Where(x=>x.Id == id).FirstOrDefault();
            _DataBaseContext.Expenses.Remove(expensesToRemove);
        }
    }
}
