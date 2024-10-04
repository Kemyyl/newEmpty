using System;
using Microsoft.AspNetCore.Mvc;
namespace newEmpty.Controllers;

public class ErrorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
