using ExpensesManagment.Web.Data.Entities;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models.ViewModel;
using ExpensesManagment.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    public class IncomeController : Controller
    {

        private readonly IncomeRepo _incomeRepo;

        private readonly IncomeService _incomeService;
        public IncomeController(IncomeRepo incomeRepo,IncomeService incomeService)
        {
            _incomeRepo = incomeRepo;
            _incomeService = incomeService;
        }
        [HttpGet]
        public IActionResult Incomes()
        {
            var Income = _incomeService.IncomeDisplay();
            return View(Income);
        }

        [HttpGet]
        public IActionResult AddIncome()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult AddIncome(Income income) 
        {
            _incomeRepo.AddIncome(income);
            return RedirectToAction("AddIncome");
        }
    }
}
