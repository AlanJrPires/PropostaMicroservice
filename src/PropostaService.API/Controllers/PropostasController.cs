using Microsoft.AspNetCore.Mvc;

namespace PropostaService.API.Controllers
{
    public class PropostasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
