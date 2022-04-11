using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using Test.Model;
using Test.Model.Common;
using Test.Repository.Common;
using Test.Common;

namespace Test.Repository 
{

    public class EmployeeRepository  :  IEmployeeRepository
    {
        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";

        SqlConnection connection = new SqlConnection(connectionString);




        public async Task<List<IEmployeeModel>> GetFromDatabaseAsync()
        {
            
            SqlCommand command = new SqlCommand("SELECT * FROM Employee ORDER BY Id ASC;", connection);
            connection.Open();
            SqlDataReader read = await command.ExecuteReaderAsync();

            if (read.HasRows)
            {
                List<IEmployeeModel> list2 = new List<IEmployeeModel>();

                while (read.Read())
                {
                    Employee emp = new Employee();
                    emp.id = read.GetInt32(0);
                    emp.firstName = read.GetString(1);
                    emp.lastName = read.GetString(2);
                    list2.Add(emp);

                }

                connection.Close();

                return list2;


            }
            else
            {
                return null;
            }


        }


        public async Task<List<IEmployeeModel>> GetWithIDAsync(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Employee WHERE Id={id};", connection);
            connection.Open();
            SqlDataReader read = await command.ExecuteReaderAsync();

            if (read.HasRows)
            {
                List<IEmployeeModel> list2 = new List<IEmployeeModel>();

                while (read.Read())
                {
                    Employee emp = new Employee();
                    emp.id = read.GetInt32(0);
                    emp.firstName = read.GetString(1);
                    emp.lastName = read.GetString(2);
                    list2.Add(emp);

                }

                connection.Close();

                return list2;

                
            }
            else
            {
                return null;
            }


        }





        public async Task<IEmployeeModel> PutEmployeeAsync(IEmployeeModel emp)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"INSERT INTO Employee VALUES ({emp.id}, '{emp.firstName}', '{emp.lastName}');", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return emp;
        }

        public async Task<IEmployeeModel> UpdateEmployeeAsync(int id, IEmployeeModel emp)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"SELECT * FROM Employee WHERE Id={id};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Employee employee = new Employee();

                while (reader.Read())
                {
                    employee.id = reader.GetInt32(0);
                    employee.firstName = emp.firstName;
                    employee.lastName = emp.lastName;
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Employee SET FirstName='{emp.firstName}',LastName='{emp.lastName}' WHERE Id={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
               await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return emp;
            }
            else
            {
                return null;
            }
        }


        public async Task<IEmployeeModel> DeleteEmployeeAsync(int id)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"SELECT * FROM Employee WHERE Id={id};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Employee emp = new Employee();

                while (reader.Read())
                {
                    emp.id = reader.GetInt32(0);
                    emp.firstName = reader.GetString(1);
                    emp.lastName = reader.GetString(2);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"DELETE FROM Employee WHERE Id={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = command2;
               await adapter.DeleteCommand.ExecuteNonQueryAsync();

                connection.Close();

                return emp;
            }
            else
            {
                return null;
            }

        }
    }
}

