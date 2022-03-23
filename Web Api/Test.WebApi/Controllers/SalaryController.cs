using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.WebApi.Models;


namespace Test.WebApi.Controllers
{
    public class SalaryController : ApiController
    {
        static List<Salary> list1 = SalaryList();


        // GET: api/Salary

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public HttpResponseMessage Get()
        {

            if (list1 == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list1);
        }



        // GET: api/Salary/5

        [HttpGet]

        //public string Get(int id)
        //{
        //    return "value";
        //}

        public HttpResponseMessage Get(int id)
        {

            if (list1.Find(x => x.EmployeeId == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list1.Find(x => x.EmployeeId == id));
        }




        // POST: api/Salary

        [HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        public HttpResponseMessage Post([FromBody]Salary sal)
        {
            list1.Add(sal);
            return Request.CreateResponse(HttpStatusCode.OK, list1);
        }


        // PUT: api/Salary/5


        //public void Put(int id, [FromBody]string value)
        //{
        //}

        public HttpResponseMessage Put(int id, [FromBody]Salary sal)
        {

            if (list1.Find(x => x.EmployeeId == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            else
            {
                Salary salary = list1.Find(x => x.EmployeeId == id);
                salary.SalaryAmount = sal.SalaryAmount;
                salary.Valute = sal.Valute;
                return Request.CreateResponse(HttpStatusCode.OK, list1.Find(x => x.EmployeeId == id));

            }

        }





        // DELETE: api/Salary/5


        //public void Delete(int id)
        //{
        //}

        public HttpResponseMessage Delete(int id, [FromBody]Salary sal)
        {

            if (list1.Find(x => x.EmployeeId == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            else
            {
                Salary salary = list1.Find(x => x.EmployeeId == id);
                list1.Remove(salary);
                return Request.CreateResponse(HttpStatusCode.OK, list1.Find(x => x.EmployeeId == id));

            }

        }



        [HttpGet]
        public static List<Salary> SalaryList()
        {
            List<Salary> list1 = new List<Salary>();
            Salary sal1 = new Salary();
            sal1.EmployeeId = 10;
            sal1.SalaryAmount = "4500";
            sal1.Valute = "Kuna";

            list1.Add(sal1);

            Salary sal2 = new Salary();
            sal2.EmployeeId = 20;
            sal2.SalaryAmount = "5300";
            sal2.Valute = "Kuna";

            list1.Add(sal2);

            Salary sal3 = new Salary();
            sal3.EmployeeId = 30;
            sal3.SalaryAmount = "1100";
            sal3.Valute = "Euro";

            list1.Add(sal3);


            return list1;

        }
    }
}
