using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxi.Controllers
{
    public class BaixarAppController : Controller
    {
        public IActionResult Baixar()
        {
            return View();
        }
    }
}
