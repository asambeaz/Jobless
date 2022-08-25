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

        public Company(int id, string name, string password, int numberOfActivePostings)
        {
            Id = id;
            Name = name;
            Password = password;
            NumberOfActivePostings = numberOfActivePostings;
        }

        public Company()
        {
            Name = "";
            Password = "";
            NumberOfActivePostings = 0;
        }
    }
}
