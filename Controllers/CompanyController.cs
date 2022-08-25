using Jobless.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobless.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index(int companyId)
        {
            if (HttpContext.Request.Cookies["user_id"] == "12345")
            {
                List<JobPosting> jobPostings = new List<JobPosting>();
                return View(jobPostings.Where(x => x.CompanyId == companyId).ToList());
            }
            return RedirectToAction(actionName: "Index", controllerName: "Error");
        }
    }
}
