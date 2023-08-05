using ExpensesManagment.Web.Data.Entities;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models.ViewModel;
using ExpensesManagment.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpensesRepo _ExpenseRepo;
        private readonly CategoryRepo _categoryRepo;
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpensesRepo expenseRepo, CategoryRepo categoryRepo,ExpenseService expenseService)
        {
            _ExpenseRepo = expenseRepo;
            _categoryRepo = categoryRepo;
            _expenseService = expenseService;
        }

        public IActionResult Expenses()
        {

            var ExpenseData = _expenseService.displayExpense();
            return View(ExpenseData);
        }


        [HttpGet]
        public IActionResult AddExpense()
        {
            var CategoryVM = new CategoryViewModel();
            CategoryVM.categoryList = _categoryRepo.categoryList();
            return View(CategoryVM);
        }


        [HttpPost]  
        public IActionResult AddExpense(Expense expense)
        {
            _ExpenseRepo.ExpenseAdd(expense);
            return RedirectToAction("AddExpense");
        }
    }
}
