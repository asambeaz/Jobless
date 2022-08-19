using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Jobless.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int NumberOfActivePostings { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]

        public Company(int id, string name, string password, int numberOfActivePostings, int jobPosting)
        {
            Id = id;
            Name = name;
            Password = password;
            NumberOfActivePostings = numberOfActivePostings;
            JobPostingId = jobPosting;
        }

        public Company()
        {
            Name = "";
            Password = "";
        }
    }
}
