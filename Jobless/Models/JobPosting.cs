using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Jobless.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public string Proffesion { get; set; }
        public string Description { get; set; }

        public JobPosting(int id, int company, string proffesion, string description)
        {
            Id = id;
            CompanyId = company;
            Proffesion = proffesion;
            Description = description;
        }

        public JobPosting()
        {
            Proffesion = "";
            Description = "";
        }
    }
}
