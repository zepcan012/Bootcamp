using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;

namespace Test.Service.Common
{
    public interface ISalaryService
    {

        Task<List<ISalaryModel>> GetSalaryAsync();
        Task<List<ISalaryModel>> GetSalaryByIDAsync(int id);
        Task<ISalaryModel> InsertSalaryAsync(ISalaryModel sal);
        Task<ISalaryModel> UpdateSalaryAsync(int id, ISalaryModel sal);
        Task<ISalaryModel> DeleteSalaryAsync(int id);

    }
}
