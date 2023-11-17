using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            
        }
        
    }
}