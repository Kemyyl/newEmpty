using System;
using Microsoft.AspNetCore.Mvc;

namespace newEmpty.Controllers;

public class LoginController : Controller
{
     public IActionResult Index()
        {
            return View();
        }
}
