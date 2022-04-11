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
using Test.Service.Common;

namespace Test.WebApi.Controllers
{
    public class SalaryController : ApiController
    {

        protected ISalaryService Service { get; set; }

        public SalaryController(ISalaryService service)
        {
            Service = service;
        }





        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";

        // GET: api/Salary

        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {

            //SalaryService service = new SalaryService();
            //List<Salary> list = new List<Salary>();

            var list = await Service.GetSalaryAsync();

            if (list.Count() > 0)
            {
                var salaryRest = new List<SalaryRest>();
                foreach (Salary sal in list)
                {
                    SalaryRest newSalary = new SalaryRest();
                    newSalary.employeeId = sal.employeeId;
                    newSalary.salaryAmount = sal.salaryAmount;
                    newSalary.valute = sal.valute;

                    salaryRest.Add(newSalary);
                }

                return Request.CreateResponse(HttpStatusCode.OK, salaryRest);

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "There are no salaries in Database!");

        }



        // GET: api/Salary/5

        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(int id)
        {

            //SalaryService service = new SalaryService();
            //List<Salary> list = new List<Salary>();

            var list = await Service.GetSalaryByIDAsync(id);

            if (list.Count() > 0)
            {
                var salaryRest = new List<SalaryRest>();
                foreach (Salary sal in list)
                {
                    SalaryRest newSalary = new SalaryRest();
                    newSalary.employeeId = sal.employeeId;
                    newSalary.salaryAmount = sal.salaryAmount;
                    newSalary.valute = sal.valute;

                    salaryRest.Add(newSalary);
                }

                return Request.CreateResponse(HttpStatusCode.OK, salaryRest);

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no salary in Database!");

        }





        // POST: api/Salary

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(Salary sal)
        {

            //SalaryService service = new SalaryService();
            //Salary newSal = new Salary();

            var newSal = await Service.InsertSalaryAsync(sal);

            SalaryRest newSalary = new SalaryRest();

            newSalary.employeeId = newSal.employeeId;
            newSalary.salaryAmount = newSal.salaryAmount;
            newSalary.valute = newSal.valute;


            return Request.CreateResponse(HttpStatusCode.OK, newSalary);

        }






        //PUT: api/Salary/5


        public async Task<HttpResponseMessage> PutAsync(int id, Salary sal)
        {

            //SalaryService service = new SalaryService();
            //Salary newSal = new Salary();

            var newSal = await Service.UpdateSalaryAsync(id, sal);

            if (newSal != null)
            {
                SalaryRest newSalary = new SalaryRest();
                newSalary.employeeId = newSal.employeeId;
                newSalary.salaryAmount = newSal.salaryAmount;
                newSalary.valute = newSal.valute;

                return Request.CreateResponse(HttpStatusCode.OK, "Salary has been updated.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary does not exist in database.");
            }

        }





        //DELETE: api/Salary/5

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {

            //SalaryService service = new SalaryService();
            //Salary newSal = new Salary();

            var newSal = await Service.DeleteSalaryAsync(id);

            if (newSal != null)
            {
                SalaryRest newSalary = new SalaryRest();
                newSalary.employeeId = newSal.employeeId;
                newSalary.salaryAmount = newSal.salaryAmount;
                newSalary.valute = newSal.valute;

                return Request.CreateResponse(HttpStatusCode.OK, "Salary has been deleted.");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary does not exist in database.");
            }

        }






        public class SalaryRest
        {
            public int employeeId { get; set; }
            public string salaryAmount { get; set; }
            public string valute { get; set; }

        }




    }
}
