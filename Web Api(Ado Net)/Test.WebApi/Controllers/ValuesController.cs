using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.WebApi.Models;
using System.Data.SqlClient;


namespace Test.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";

        static List<Employee> list2 = new List<Employee>();


        // GET api/values
        [HttpGet]
        
        public HttpResponseMessage Get()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employee;", connection);
                SqlDataReader read = command.ExecuteReader();



                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = read.GetInt32(0);
                        emp.FirstName = read.GetString(1);
                        emp.LastName = read.GetString(2);

                        list2.Add(emp);


                    }


                    return Request.CreateResponse(HttpStatusCode.OK, list2);
                    connection.Close();

                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                    //connection.Close();

                }
            }


        }


        // GET api/values/5
        [HttpGet]
       
        public HttpResponseMessage Get(int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE Id = " + id + ";", connection);
                SqlDataReader read = command.ExecuteReader();



                if (read.HasRows)
                {
                    while (read.Read())
                    {

                        Employee emp = new Employee();
                        emp.Id = read.GetInt32(0);
                        emp.FirstName = read.GetString(1);
                        emp.LastName = read.GetString(2);

                        list2.Add(emp);


                    }


                    return Request.CreateResponse(HttpStatusCode.OK, list2);
                    connection.Close();
                    

                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                    //connection.Close();

                }
            }


        }


        // POST api/values
        [HttpPost]
        
        public HttpResponseMessage Post([FromBody]Employee emp)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {

                SqlCommand command = new SqlCommand($"INSERT INTO Employee (Id, FirstName, LastName) VALUES ('{emp.Id}','{emp.FirstName}', '{emp.LastName}');", connection);
                command.ExecuteNonQuery();

                list2.Add(emp);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Employee has been added to the database!");

            connection.Close();

        }
        


        // PUT api/values/5
       
        public HttpResponseMessage Put(int id, [FromBody]Employee emp)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
           
                SqlCommand command = new SqlCommand($"UPDATE Employee SET FirstName ='{emp.FirstName}', LastName ='{emp.LastName}' WHERE Id ='{emp.Id}';", connection);
                command.ExecuteNonQuery();

                list2.Add(emp);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Employee has been updated!");

            connection.Close();

        }






        // DELETE api/values/5

        public HttpResponseMessage Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection) 
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Employee WHERE Id ='{id}';", connection);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee has been deleted!");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee doesn't exist");
            }




        }


       
    }
}
