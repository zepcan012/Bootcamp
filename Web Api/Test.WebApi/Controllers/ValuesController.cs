using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.WebApi.Models;

namespace Test.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<Employee> list = EmployeeList();

        // GET api/values
        [HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    //List<Employee> list = EmployeeList();
        //    return list;
        //}



        public HttpResponseMessage Get()
        {

            if (list == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }


        // GET api/values/5
        [HttpGet]
        //public Employee Get(int id)
        //{
        //    //List<Employee> list = EmployeeList();
        //    return list.Find(x => x.Id == id);
        //    //return "value";
        //}


        public HttpResponseMessage Get(int id)
        {

            if (list.Find(x => x.Id == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list.Find(x => x.Id == id));
        }


        // POST api/values
        [HttpPost]
        //public IEnumerable<Employee> Post([FromBody]Employee emp)
        //{

        //    //List<Employee> list = new List<Employee>();
        //    list.Add(emp);
        //    return list;
        //}

        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            list.Add(emp);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }




        // PUT api/values/5
        //public IEnumerable<Employee> Put(int id, [FromBody]Employee emp)
        //{
        //    //List<Employee> list = EmployeeList();
        //    Employee employee = list.Find(x => x.Id == id);
        //    employee.FirstName = emp.FirstName;
        //    employee.LastName = emp.LastName;
        //    return list;
        //}

        

        public HttpResponseMessage Put(int id, [FromBody]Employee emp)
        {

            if (list.Find(x => x.Id == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            else
            {
                Employee employee = list.Find(x => x.Id == id);
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                return Request.CreateResponse(HttpStatusCode.OK, list.Find(x => x.Id == id));

            }

        }



        // DELETE api/values/5
        //public IEnumerable<Employee> Delete(int id)
        //{
        //    //List<Employee> list = EmployeeList();
        //    Employee employee = list.Find(x => x.Id == id);

        //    list.Remove(employee);
        //    return list;
        //}

       

        public HttpResponseMessage Delete(int id, [FromBody]Employee emp)
        {

            if (list.Find(x => x.Id == id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            else
            {
                Employee employee = list.Find(x => x.Id == id);
                list.Remove(employee);
                return Request.CreateResponse(HttpStatusCode.OK, list.Find(x => x.Id == id));

            }

        }

        [HttpGet]
        public static List<Employee> EmployeeList()
        {
            List<Employee> list = new List<Employee>();
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.FirstName = "Ivan";
            emp1.LastName = "Ivic";

            list.Add(emp1);

            Employee emp2 = new Employee();
            emp2.Id = 2;
            emp2.FirstName = "Pero";
            emp2.LastName = "Peric";

            list.Add(emp2);

            Employee emp3 = new Employee();
            emp3.Id = 3;
            emp3.FirstName = "Anica";
            emp3.LastName = "Anic";

            list.Add(emp3);


            return list;

        }
    }
}
