using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagment.Web.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
