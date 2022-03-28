using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Test.WebApi.Models;


namespace Test.WebApi.Controllers
{
    public class SalaryController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";


        static List<Salary> list2 = new List<Salary>();

        // GET: api/Salary


        [HttpGet]
       
        public HttpResponseMessage Get()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Salary;", connection);
                SqlDataReader read = command.ExecuteReader();

               

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        //List<Salary> people = new List<Salary>();
                        Salary sal = new Salary();
                        sal.EmployeeId = read.GetInt32(0);
                        sal.SalaryAmount = read.GetString(1);
                        sal.Valute = read.GetString(2);

                        list2.Add(sal);


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





        // GET: api/Salary/5

        [HttpGet]

      

        public HttpResponseMessage Get(int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Salary WHERE EmployeeID = "+ id + ";", connection);
                SqlDataReader read = command.ExecuteReader();



                if (read.HasRows)
                {
                    while (read.Read())
                    {

                        Salary sal = new Salary();
                        sal.EmployeeId = read.GetInt32(0);
                        sal.SalaryAmount = read.GetString(1);
                        sal.Valute = read.GetString(2);

                        list2.Add(sal);


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




        // POST: api/Salary

        [HttpPost]
       
        public HttpResponseMessage Post([FromBody]Salary sal)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
            
                SqlCommand command = new SqlCommand($"INSERT INTO Salary (EmployeeID, SalaryAmount, Valute) VALUES ('{sal.EmployeeId}','{sal.SalaryAmount}', '{sal.Valute}');", connection);
                command.ExecuteNonQuery();

                list2.Add(sal);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Salary has been added  in database!");

            connection.Close();

        }



        //PUT: api/Salary/5



        public HttpResponseMessage Put(int id, [FromBody]Salary sal)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {

                SqlCommand command = new SqlCommand($"UPDATE Salary SET SalaryAmount ='{sal.SalaryAmount}', Valute ='{sal.Valute}' WHERE EmployeeID ='{sal.EmployeeId}';", connection);
                command.ExecuteNonQuery();

                list2.Add(sal);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Salary has been updated!");

            connection.Close();

        }







        //DELETE: api/Salary/5



        public HttpResponseMessage Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Salary WHERE EmployeeID ='{id}';", connection);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return Request.CreateResponse(HttpStatusCode.OK, "Salary has been deleted!");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Salary doesn't exist");
            }




        }



    }
}
