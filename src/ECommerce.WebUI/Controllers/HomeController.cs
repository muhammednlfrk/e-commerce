using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers;

[Route("")]
public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
