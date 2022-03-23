using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Test.WebApi.Models
{
    public class Salary
    {
        public int EmployeeId { get; set; }
        public string SalaryAmount { get; set; }
        public string Valute { get; set; }
    }
}