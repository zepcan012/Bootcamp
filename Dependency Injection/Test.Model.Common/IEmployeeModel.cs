using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Common
{
   public interface IEmployeeModel
    {
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }

    }
}
