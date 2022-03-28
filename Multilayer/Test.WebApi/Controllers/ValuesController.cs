using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Test.Service;
using Test.Model;


namespace Test.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";

       



        // GET api/values

       

        [HttpGet]
        public async Task <HttpResponseMessage> GetAsync()
        {

            EmployeeService service = new EmployeeService();
            List<Employee> list = new List<Employee>();

            list = await service.GetEmployeeAsync();

            if (list.Count() > 0)
            {
                List<EmployeeRest> employeeRest = new List<EmployeeRest>();
                foreach (Employee emp in list)
                {
                    EmployeeRest newEmployee = new EmployeeRest();
                    newEmployee.id = emp.id;
                    newEmployee.firstName = emp.firstName;
                    newEmployee.lastName = emp.lastName;

                    employeeRest.Add(newEmployee);
                }

                return Request.CreateResponse(HttpStatusCode.OK, employeeRest);

            } 
                
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no employees in Database!");
                
        }




        // GET api/values/5
        

        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(int id)
        {

            EmployeeService service = new EmployeeService();
            List<Employee> list = new List<Employee>();

            list = await service.GetEmployeeByIDAsync(id);

            if (list.Count() > 0)
            {
                List<EmployeeRest> employeeRest = new List<EmployeeRest>();
                foreach (Employee emp in list)
                {
                    EmployeeRest newEmployee = new EmployeeRest();
                    newEmployee.id = emp.id;
                    newEmployee.firstName = emp.firstName;
                    newEmployee.lastName = emp.lastName;

                    employeeRest.Add(newEmployee);
                }

                return Request.CreateResponse(HttpStatusCode.OK, employeeRest);

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "There are no employees in Database!");

        }






        // POST api/values
       

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(Employee emp)
        {

            EmployeeService service = new EmployeeService();
            Employee newEmp = new Employee();

            newEmp = await service.InsertEmployeeAsync(emp);

            EmployeeRest newEmployee = new EmployeeRest();

            newEmployee.id = newEmp.id;
            newEmployee.firstName = newEmp.firstName;
            newEmployee.lastName = newEmp.lastName;


            return Request.CreateResponse(HttpStatusCode.OK, newEmployee);

        }





        // PUT api/values/5
       
        public async Task<HttpResponseMessage> PutAsync(int id, Employee emp)
        {

            EmployeeService service = new EmployeeService();
            Employee newEmp = new Employee();

            newEmp = await service.UpdateEmployeeAsync(id, emp);

            if (newEmp != null)
            {
                EmployeeRest newEmployee = new EmployeeRest();
                newEmployee.id = newEmp.id;
                newEmployee.firstName = newEmp.firstName;
                newEmployee.lastName = newEmp.lastName;

                return Request.CreateResponse(HttpStatusCode.OK, "Employee has been updated.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee does not exist in database.");
            }

        }




        // DELETE api/values/5
   

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {

            EmployeeService service = new EmployeeService();
            Employee newEmp = new Employee();

            newEmp = await service.DeleteEmployeeAsync(id);

            if (newEmp != null)
            {
                EmployeeRest newEmployee = new EmployeeRest();
                newEmployee.id = newEmp.id;
                newEmployee.firstName = newEmp.firstName;
                newEmployee.lastName = newEmp.lastName;

                return Request.CreateResponse(HttpStatusCode.OK, "Employee has been deleted.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee does not exist in database.");
            }

        }


        public class EmployeeRest
        {

            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }

        }


    }
}
