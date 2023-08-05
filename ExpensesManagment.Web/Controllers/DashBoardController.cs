
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models.ViewModel;
using ExpensesManagment.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly IncomeService _IncomeService;
        private readonly ExpenseService _expenseService;
        private readonly DashBoardServices _dashboardServices;
        public DashBoardController(ExpenseService expenseService,CategoryRepo categoryRepo,DashBoardServices dashBoardServices,IncomeService IncomeService)
        {
            _expenseService = expenseService;
            _categoryRepo = categoryRepo;
            _dashboardServices = dashBoardServices;
            _IncomeService = IncomeService;
        }
        public IActionResult DashBoard()
        {
            var DashBoardVM = new DashBoardViewModel();
            DashBoardVM.LastFiveExpenses = _expenseService.LastFiveExpenses();
            DashBoardVM.ExpensesMonthly = _expenseService.Expenses("Monthly") ;
            DashBoardVM.MonthlyIncome = _IncomeService.Incomes("Monthly");
            DashBoardVM.AnnualIncome = _IncomeService.Incomes("Annual");
            DashBoardVM.ExpensesAnnaul = _expenseService.Expenses("Yearly");
            DashBoardVM.Average = 000;
            DashBoardVM.categories = _categoryRepo.categoryList();

            //DashBoardVM.MonthlyPieChartData = _dashboardServices.MonthlyPieChart();
            return View(DashBoardVM);
        }
    }
}
