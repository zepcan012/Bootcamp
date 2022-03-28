using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string SalaryAmount { get; internal set; }
        //public string Valute { get; internal set; }
    }
}