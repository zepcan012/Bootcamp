using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using Test.Model;
using Test.Repository;
using System.Threading.Tasks;


namespace Test.Service
{
    public class EmployeeService
    {
        public async Task<List<Employee>> GetEmployeeAsync()
        {
            EmployeeRepository getData = new EmployeeRepository();
            return await getData.GetFromDatabaseAsync();

        }

        public async Task<List<Employee>> GetEmployeeByIDAsync(int id)
        {
            EmployeeRepository getID = new EmployeeRepository();
            return await getID.GetWithIDAsync(id);

        }


        public  async Task<Employee> InsertEmployeeAsync(Employee emp)
        {
            EmployeeRepository insertEmp = new EmployeeRepository();

            return await insertEmp.PutEmployeeAsync(emp);
        }


        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {
            EmployeeRepository updateEmp = new EmployeeRepository();
            return await updateEmp.UpdateEmployeeAsync(id, emp);

        }


        public async Task <Employee> DeleteEmployeeAsync(int id)
        {
            EmployeeRepository emp = new EmployeeRepository();

            return await emp.DeleteEmployeeAsync(id);
        }



    }
}
