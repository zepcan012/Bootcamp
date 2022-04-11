using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;

namespace Test.Model
{
    public class Employee : IEmployeeModel
    {
       
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
           
    }
}
