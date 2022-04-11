using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using Test.Model;
using Test.Repository;
using System.Threading.Tasks;
using Test.Service.Common;
using Test.Model.Common;
using Test.Repository.Common;

namespace Test.Service
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository EmployeeRepository;


        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }


        public async Task<List<IEmployeeModel>> GetEmployeeAsync()
        {
            return await EmployeeRepository.GetFromDatabaseAsync();

        }

        public async Task<List<IEmployeeModel>> GetEmployeeByIDAsync(int id)
        {

            return await EmployeeRepository.GetWithIDAsync(id);

        }


        public async Task<IEmployeeModel> InsertEmployeeAsync(IEmployeeModel emp)
        {

            return await EmployeeRepository.PutEmployeeAsync(emp);
        }


        public async Task<IEmployeeModel> UpdateEmployeeAsync(int id, IEmployeeModel emp)
        {

            return await EmployeeRepository.UpdateEmployeeAsync(id, emp);

        }


        public async Task<IEmployeeModel> DeleteEmployeeAsync(int id)
        {

            return await EmployeeRepository.DeleteEmployeeAsync(id);
        }




        //public async Task<List<Employee>> GetEmployeeAsync()
        //{
        //    EmployeeRepository getData = new EmployeeRepository();
        //    return await getData.GetFromDatabaseAsync();

        //}

        //public async Task<List<Employee>> GetEmployeeByIDAsync(int id)
        //{
        //    EmployeeRepository getID = new EmployeeRepository();
        //    return await getID.GetWithIDAsync(id);

        //}


        //public  async Task<Employee> InsertEmployeeAsync(Employee emp)
        //{
        //    EmployeeRepository insertEmp = new EmployeeRepository();

        //    return await insertEmp.PutEmployeeAsync(emp);
        //}


        //public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        //{
        //    EmployeeRepository updateEmp = new EmployeeRepository();
        //    return await updateEmp.UpdateEmployeeAsync(id, emp);

        //}


        //public async Task <Employee> DeleteEmployeeAsync(int id)
        //{
        //    EmployeeRepository emp = new EmployeeRepository();

        //    return await emp.DeleteEmployeeAsync(id);
        //}



    }
}
