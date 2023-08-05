using ExpensesManagment.Web.Data.Entities;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryRepo _categoryRepo;
        public CategoryController(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        public IActionResult Categories()
        {
            var CategoryVM = new CategoryViewModel();
            CategoryVM.categoryList = _categoryRepo.categoryList();
            return View(CategoryVM);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var CategoryOBJ = new Category();
            return View(CategoryOBJ);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryRepo.AddCategory(category);
            return RedirectToAction("Categories");
        }
    }
}
