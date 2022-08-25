using Jobless.Data;
using Jobless.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jobless.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public RedirectToActionResult Add(string name, string password, int numberOfActivePostings)
        {
            var id = 0L;
            if (name == null || password == null)
            {
                return RedirectToAction(actionName: "Create", controllerName: "Login");
            }
            if(!DataService.GetCompanies().Any(x => x.Name == name && x.Password == password))
            {
                id = DataService.AddCompany(name, password, numberOfActivePostings=0);
            }
            HttpContext.Response.Cookies.Append("user_id", "12345");
            return RedirectToAction(actionName: "Index", controllerName: "Company", new { companyId = id } );
        }

/*        public IActionResult Index(int companyId)
        {
            if (HttpContext.Request.Cookies["user_id"] == "12345")
            {
                List<JobPosting> jobPostings = new List<JobPosting>();
                return View(jobPostings.Where(x => x.CompanyId == companyId).ToList());
            }
            return RedirectToAction(actionName: "Index", controllerName: "Error");
            if (DataService.GetJobPostings().Any(x => x.CompanyId == companyId))
            {
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }*/

/*        public RedirectToActionResult Index_Postings(int companyId)
        {
            if (!DataService.GetJobPostings().Any(x => x.CompanyId == companyId))
            {
                return 
            }
        }*/

/*        public RedirectToActionResult Add_1()
        {
            HttpContext.Response.Cookies.Append("user_id", "2");

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }*/

/*        public string Kuki() {
            return HttpContext.Request.Cookies["user_id"];
        }*/
    }
}
