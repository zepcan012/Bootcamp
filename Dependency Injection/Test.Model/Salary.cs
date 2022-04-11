using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common;
using Test.Model.Common;

namespace Test.Model
{
    public class Salary : ISalaryModel
    { 
        public int employeeId { get; set; }
        public string salaryAmount { get; set; }
        public string valute { get; set; }

    }
}
