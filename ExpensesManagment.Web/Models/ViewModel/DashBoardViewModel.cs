using ExpensesManagment.Web.Data.Entities;

namespace ExpensesManagment.Web.Models.ViewModel
{
    public class DashBoardViewModel
    {
        public List<Category> categories { get; set; }
        public int MonthlyIncome { get; set; }
        public int AnnualIncome { get; set; }
        public int ExpensesMonthly { get; set; }
        public int ExpensesAnnaul { get; set; }
        public int Average { get; set; }
        public List<DisplayExpenseModel> LastFiveExpenses { get; set; }
        //public List<PieChartData> MonthlyPieChartData { get; set;}
        //public List<PieChartData> YearlyPieChartData { get; set; }
    }
}
