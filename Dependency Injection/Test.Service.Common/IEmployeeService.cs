using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;

namespace Test.Service.Common
{
    public interface IEmployeeService
    {
        Task<List<IEmployeeModel>> GetEmployeeAsync();
        Task<List<IEmployeeModel>> GetEmployeeByIDAsync(int id);
        Task<IEmployeeModel> InsertEmployeeAsync(IEmployeeModel emp);
        Task<IEmployeeModel> UpdateEmployeeAsync(int id, IEmployeeModel emp);
        Task<IEmployeeModel> DeleteEmployeeAsync(int id);
    }
}
