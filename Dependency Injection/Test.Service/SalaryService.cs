using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Model.Common;
using Test.Repository;
using Test.Repository.Common;
using Test.Service.Common;

namespace Test.Service
{
    public class SalaryService : ISalaryService
    {

        public ISalaryRepository SalaryRepository;


        public SalaryService(ISalaryRepository salaryRepository)
        {
            this.SalaryRepository = salaryRepository;
        }

        public async Task<List<ISalaryModel>> GetSalaryAsync()
        {
            return await SalaryRepository.GetFromDatabaseAsync();

        }

        public async Task<List<ISalaryModel>> GetSalaryByIDAsync(int id)
        {
            return await SalaryRepository.GetWithIDAsync(id);

        }


        public async Task<ISalaryModel> InsertSalaryAsync(ISalaryModel sal)
        {

            return await SalaryRepository.PutSalaryAsync(sal);
        }


        public async Task<ISalaryModel> UpdateSalaryAsync(int id, ISalaryModel sal)
        {
            return await SalaryRepository.UpdateAsync(id, sal);

        }


        public async Task<ISalaryModel> DeleteSalaryAsync(int id)
        {

            return await SalaryRepository.DeleteAsync(id);
        }









        //public async Task<List<Salary>> GetSalaryAsync()
        //{
        //    SalaryRepository getData = new SalaryRepository();
        //    return await getData.GetFromDatabaseAsync();

        //}

        //public async Task<List<Salary>> GetSalaryByIDAsync(int id)
        //{
        //    SalaryRepository getID = new SalaryRepository();
        //    return await getID.GetWithIDAsync(id);

        //}


        //public async Task<Salary> InsertSalaryAsync(Salary sal)
        //{
        //    SalaryRepository insertSal = new SalaryRepository();

        //    return await insertSal.InputSalaryAsync(sal);
        //}


        //public async Task<Salary> UpdateSalaryAsync(int id, Salary sal)
        //{
        //    SalaryRepository updateSal = new SalaryRepository();
        //    return await updateSal.UpdateAsync(id, sal);

        //}


        //public async Task<Salary> DeleteSalaryAsync(int id)
        //{
        //    SalaryRepository sal = new SalaryRepository();

        //    return await sal.DeleteAsync(id);
        //}


    }
}
