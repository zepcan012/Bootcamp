using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Repository;

namespace Test.Service
{
    public class SalaryService
    {
        public async Task<List<Salary>> GetSalaryAsync()
        {
            SalaryRepository getData = new SalaryRepository();
            return await getData.GetFromDatabaseAsync();

        }

        public async Task<List<Salary>> GetSalaryByIDAsync(int id)
        {
            SalaryRepository getID = new SalaryRepository();
            return await getID.GetWithIDAsync(id);

        }


        public async Task<Salary> InsertSalaryAsync(Salary sal)
        {
            SalaryRepository insertSal = new SalaryRepository();

            return await insertSal.InputSalaryAsync(sal);
        }


        public async Task<Salary> UpdateSalaryAsync(int id, Salary sal)
        {
            SalaryRepository updateSal = new SalaryRepository();
            return await updateSal.UpdateAsync(id, sal);

        }


        public async Task<Salary> DeleteSalaryAsync(int id)
        {
            SalaryRepository sal = new SalaryRepository();

            return await sal.DeleteAsync(id);
        }


    }
}
