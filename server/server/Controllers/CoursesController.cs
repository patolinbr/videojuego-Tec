using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

public class CoursesController : Controller
{
    // GET
    public IActionResult Course()
    {
        return View();
    }
}