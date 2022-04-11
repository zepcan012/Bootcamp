using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;

namespace Test.Repository.Common
{
    public interface ISalaryRepository
    {

        Task<List<ISalaryModel>> GetFromDatabaseAsync();
        Task<List<ISalaryModel>> GetWithIDAsync(int id);
        Task<ISalaryModel> PutSalaryAsync(ISalaryModel sal);
        Task<ISalaryModel> UpdateAsync(int id, ISalaryModel sal);
        Task<ISalaryModel> DeleteAsync(int id);

    }
}
