using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makani.Controllers.Web
{
    public class CheckoutController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }
    }
}
