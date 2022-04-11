using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;

namespace Test.Repository.Common
{
    public interface IEmployeeRepository
    {

        Task<List<IEmployeeModel>> GetFromDatabaseAsync();
        Task<List<IEmployeeModel>> GetWithIDAsync(int id);
        Task<IEmployeeModel> PutEmployeeAsync(IEmployeeModel emp);
        Task<IEmployeeModel> UpdateEmployeeAsync(int id, IEmployeeModel emp);
        Task<IEmployeeModel> DeleteEmployeeAsync(int id);


    }
}
