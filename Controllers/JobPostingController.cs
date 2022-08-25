using Jobless.Data;
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
        public RedirectToActionResult Add_Job_Posting(int companyId, string proffesion, string description, bool isActive)
        {
            if (description == null)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddJobPosting(companyId, proffesion, description, isActive = false);
            return RedirectToAction(actionName: "Index", controllerName: "Company");
        }

        public IActionResult Activation(int id)
        {
            if (!DataService.GetJobPostings().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetJobPostings().FirstOrDefault(x => x.Id == id));
        }
        public RedirectToActionResult Activate_Job_Posting(int id, bool isActive)
        {
            DataService.EditJobPosting(id, isActive);
            return RedirectToAction(actionName: "Index", controllerName: "Company");
        }

    }
}
