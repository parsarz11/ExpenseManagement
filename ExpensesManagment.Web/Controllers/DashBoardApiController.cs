using ExpensesManagment.Web.Data.Entities;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DashBoardApiController : ControllerBase
    {
        private readonly DashBoardServices _DashBoardSevices;
        public DashBoardApiController(DashBoardServices dashBoardServices)
        {
            _DashBoardSevices = dashBoardServices;
        }

        [HttpGet]
        public IActionResult ExpensesChart(int id)
        {
            var ExpensesChart = _DashBoardSevices.GetExpenses(id);

            return Ok(ExpensesChart);
        }

        [HttpGet]
        public IActionResult MonthlyPieChart(string Type)
        {
           if(Type == "monthly")
            {
                var pieChartData = _DashBoardSevices.MonthlyPieChart();
                return Ok(pieChartData);
            }
            else
            {
                var pieChartData = _DashBoardSevices.YearlyPieChart();
                return Ok(pieChartData);
            }
        }
    }
}
