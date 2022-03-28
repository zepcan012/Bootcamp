using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Test.Model;

namespace Test.Repository
{
   public class SalaryRepository
    {
        static string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public async Task<List<Salary>> GetFromDatabaseAsync()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Salary;", connection);
            connection.Open();
            SqlDataReader read = await command.ExecuteReaderAsync();

            if (read.HasRows)
            {
                List<Salary> list2 = new List<Salary>();

                while (read.Read())
                {
                    Salary salary = new Salary();
                    salary.employeeId = read.GetInt32(0);
                    salary.salaryAmount = read.GetString(1);
                    salary.valute = read.GetString(2);
                    list2.Add(salary);

                }

                connection.Close();

                return list2;


            }
            else
            {
                return null;
            }


        }


        public async Task<List<Salary>> GetWithIDAsync(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Salary WHERE EmployeeId={id};", connection);
            connection.Open();
            SqlDataReader read = await command.ExecuteReaderAsync();

            if (read.HasRows)
            {
                List<Salary> list2 = new List<Salary>();

                while (read.Read())
                {
                    Salary salary = new Salary();
                    salary.employeeId = read.GetInt32(0);
                    salary.salaryAmount = read.GetString(1);
                    salary.valute = read.GetString(2);
                    list2.Add(salary);

                }

                connection.Close();

                return list2;


            }
            else
            {
                return null;
            }


        }


        public async Task<Salary> InputSalaryAsync(Salary sal)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"INSERT INTO Salary VALUES ({sal.employeeId}, '{sal.salaryAmount}', '{sal.valute}');", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return sal;
        }

      
        public async Task<Salary> UpdateAsync(int id, Salary sal)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"SELECT * FROM Salary WHERE EmployeeID={id};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Salary salary = new Salary();

                while (reader.Read())
                {
                    salary.employeeId = reader.GetInt32(0);
                    salary.salaryAmount = sal.salaryAmount;
                    salary.valute = sal.valute;
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Salary SET SalaryAmount='{sal.salaryAmount}', Valute='{sal.valute}' WHERE EmployeeID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return sal;
            }
            else
            {
                return null;
            }
        }



        public async Task<Salary> DeleteAsync(int id)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"SELECT * FROM Salary WHERE EmployeeID={id};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Salary salary = new Salary();

                while (reader.Read())
                {
                    salary.employeeId = reader.GetInt32(0);
                    salary.salaryAmount = reader.GetString(1);
                    salary.valute = reader.GetString(2);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"DELETE FROM Salary WHERE EmployeeID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = command2;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();

                connection.Close();

                return salary;
            }
            else
            {
                return null;
            }



        }




    }
}
