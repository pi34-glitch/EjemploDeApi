using Microsoft.AspNetCore.Mvc;

namespace EjemploDeApi.Controllers
{
    public class ReservasViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}