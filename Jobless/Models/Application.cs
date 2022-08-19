using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Jobless.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Proffesion { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]

        public Application(int id, string name, string proffesion, int jobPosting)
            {
            Id = id;
            Name = name;
            Proffesion = proffesion;
            JobPostingId = jobPosting;
            }

        public Application()
        {
            Name = "";
            Proffesion = "";
        }
    }
}
