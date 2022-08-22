using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobless.Controllers
{
    public class JobPostingController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
