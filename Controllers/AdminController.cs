using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Proprietario()
        {
            return View();
        }
        public IActionResult Passageiro()
        {
            return View();

        }
    }
}