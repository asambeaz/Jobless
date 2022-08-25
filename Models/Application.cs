using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Jobless.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JobPostingId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public JobPosting JobPosting { get; set; }

        public Application(int id, string name, int jobPosting)
            {
            Id = id;
            Name = name;
            JobPostingId = jobPosting;
            }

        public Application()
        {
            Name = "";
        }
    }
}
