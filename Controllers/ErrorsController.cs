using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace New.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index(string errMessage)
        {
            ViewBag.errMessage = errMessage;
            return View();
        }
    }
}