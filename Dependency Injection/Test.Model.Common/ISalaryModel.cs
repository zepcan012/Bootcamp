using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Common
{
    public interface ISalaryModel
    {
        int employeeId { get; set; }
        string salaryAmount { get; set; }
        string valute { get; set; }

    }
}
