using ExpensesManagment.Web.Data.Entities;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models.ChartsDisplayModel;
using ExpensesManagment.Web.Models.ViewModel;

namespace ExpensesManagment.Web.Services
{
    public class DashBoardServices
    {
        private ExpensesRepo _expenseRepo;
        private readonly CategoryRepo _categoryRepo;

        public DashBoardServices(ExpensesRepo expenseService,CategoryRepo categoryRepo)
        {
            _expenseRepo = expenseService;
            //_categorySevice = categorySevice;
            _categoryRepo = categoryRepo;
        }

        public DisplayExpenseChartModel GetExpenses(int id)
        {

            if (id == 0)
            {
                var AllMonth = _expenseRepo.ExpenseList().Select(x => x.DateTime.Month).Distinct().ToList();

                var AllAvgExpenses = _expenseRepo.ExpenseList().GroupBy(x => x.DateTime.Month).Select(x => x.Average(y => y.Cost)).ToList();

                var AllChartDisplayModel = new DisplayExpenseChartModel()
                {
                    Month = AllMonth,
                    ExpenseValue = AllAvgExpenses,
                };

                return AllChartDisplayModel;
            }
            else
            {
                var Month = _expenseRepo.ExpenseList().Where(x => x.CategoryFK == id).Select(x => x.DateTime.Month).Distinct().ToList();

                var avgExpenses = _expenseRepo.ExpenseList().Where(p => p.CategoryFK == id).GroupBy(x => x.DateTime.Month).Select(x => x.Average(y => y.Cost)).ToList();

                var ChartDisplayModel = new DisplayExpenseChartModel()
                {
                    Month = Month,
                    ExpenseValue = avgExpenses,
                };

                return ChartDisplayModel;
            }
            
        }


        public List<PieChartData> MonthlyPieChart()
        {
            var expenses = _expenseRepo.ExpenseList();
            var categories = _categoryRepo.categoryList();


            var pieChartDataSet = categories.Select(x =>
            {
                var thisCategoryExpensesSum = expenses.Where(y => y.DateTime.Month == DateTime.Now.Month && y.CategoryFK == x.Id).Sum(s => s.Cost);
                var categoryname = x.Name;

                var pichartRecord = new PieChartData
                {
                    name = categoryname,
                    value = thisCategoryExpensesSum
                };

                return pichartRecord;

            })
            .ToList();


            return pieChartDataSet;

            
        }


        public List<PieChartData> YearlyPieChart()
        {
            var expenses = _expenseRepo.ExpenseList();
            var categories = _categoryRepo.categoryList();


            var pieChartDataSet = categories.Select(x =>
            {
                var thisCategoryExpensesSum = expenses.Where(y => y.DateTime.Year == DateTime.Now.Year && y.CategoryFK == x.Id).Sum(s => s.Cost);
                var categoryname = x.Name;

                var pichartRecord = new PieChartData
                {
                    name = categoryname,
                    value = thisCategoryExpensesSum
                };

                return pichartRecord;

            })
            .ToList();


            return pieChartDataSet;
        }

    }
}
