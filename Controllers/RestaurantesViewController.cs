using Microsoft.AspNetCore.Mvc;

namespace EjemploDeApi.Controllers
{
    public class RestaurantesViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
