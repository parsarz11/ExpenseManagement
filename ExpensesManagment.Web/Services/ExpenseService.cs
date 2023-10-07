using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models;
using System.Globalization;

namespace ExpensesManagment.Web.Services
{
    public class ExpenseService
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly ExpensesRepo _expensesRepo;
        private PersianCalendar PC;

        public ExpenseService(CategoryRepo categoryRepo, ExpensesRepo expensesRepo)
        {
            _categoryRepo = categoryRepo;
            _expensesRepo = expensesRepo;
            PC = new PersianCalendar();
        }

        public List<DisplayExpenseModel> displayExpense()
        {
            var Categories = _categoryRepo.categoryList();
            var Expenses = _expensesRepo.ExpenseList();

            var DisplayExpenses = Expenses.Select(x =>
            {
                var Category = Categories.Where(y => y.Id == x.CategoryFK).FirstOrDefault();
                var DisplayModel = new DisplayExpenseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    Date = string.Format($"{PC.GetYear(x.DateTime)}/{PC.GetMonth(x.DateTime)}/{PC.GetDayOfMonth(x.DateTime)}"),
                    Category = Category.Name,
                    CategoryColor = Category.Color,

                };
                return DisplayModel;
            }).ToList();
            return DisplayExpenses;
        }


        public List<DisplayExpenseModel> LastFiveExpenses()
        {
            var Categories = _categoryRepo.categoryList();
            var Expenses = _expensesRepo.ExpenseList().OrderByDescending(x=>x.DateTime).Take(5).ToList();

            var DisplayExpenses = Expenses.Select(x =>
            {
                var Category = Categories.Where(y => y.Id == x.CategoryFK).FirstOrDefault();
                var DisplayModel = new DisplayExpenseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    Date = string.Format($"{PC.GetYear(x.DateTime)}/{PC.GetMonth(x.DateTime)}/{PC.GetDayOfMonth(x.DateTime)}"),
                    Category = Category.Name,
                    CategoryColor = Category.Color,

                };
                return DisplayModel;
            }).ToList();
            return DisplayExpenses;
        }



        public int Expenses(string Type)
        {
            if( Type == "Monthly")
            {
                int MonthlyExpenses = _expensesRepo.ExpenseList().Where(x => x.DateTime.Month == DateTime.Now.Month).Select(y => y.Cost).Sum();
                return MonthlyExpenses;
            }
            else
            {
                int YearlyExpenses = _expensesRepo.ExpenseList().Where(x => x.DateTime.Year == DateTime.Now.Year).Select(y => y.Cost).Sum();
                return YearlyExpenses;
            }
        }
    }
}
