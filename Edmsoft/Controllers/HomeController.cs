using Edmsoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Edmsoft.Controllers
{
    public class HomeController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
    }
}
