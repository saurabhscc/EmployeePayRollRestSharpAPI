using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRoll
{
    //Business logic
    public class EmployeeOperation
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRoll";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //instance
        public static Employee employee = new Employee();
        readonly List<Employee> empList = new List<Employee>();
        /// <summary>
        /// Get the employee detail by store procedure
        /// </summary>
        public List<Employee> GetAllEmployeeDetails()
        {
            this.sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand("spGetAllEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow data in dataTable.Rows)
                {
                    Console.WriteLine("No record found");
                    empList.Add
                        (
                            new Employee
                            {
                                ID = Convert.ToInt32(data["Id"]),
                                Name = Convert.ToString(data["Name"]),
                                Gender = Convert.ToString(data["Gender"]),
                                phone_Number = Convert.ToString(data["phone_Number"]),
                                Address = Convert.ToString(data["Address"]),
                                Department = Convert.ToString(data["Department"]),
                                BasicPay = Convert.ToInt32(data["BasicPay"]),
                                Deduction = Convert.ToDouble(data["Deduction"]),
                                TaxablePay = Convert.ToDouble(data["TaxablePay"]),
                                Tax = Convert.ToDouble(data["Tax"]),
                                NetPay = Convert.ToDouble(data["NetPay"]),
                                StartDate = Convert.ToDateTime(data["StartDate"]),

                            }
                        );
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return empList;

        }
        /// <summary>
        /// update the employee salary
        /// </summary>
        public int UpdateEmployeeSalary()
        {
            Employee emp = new Employee();
            emp.Name = "Terissa";
            emp.BasicPay = 3000000;
            try
            {
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", emp.Name);
                sqlCommand.Parameters.AddWithValue("@BasicPay", emp.BasicPay);
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Salary is updated...");
                else
                    Console.WriteLine("Salary not updated!");
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        /// <summary>
        /// get employee details between start and end date
        /// </summary>
        public void GetEmployeeDetailsByDate()
        {
            Employee employee = new Employee();
            DateTime startDate = new DateTime(1997, 01, 10);
            DateTime endDate = new DateTime(2010, 04, 15);
            try
            {
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetDataByDate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StartDate", startDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee.ID = reader.GetInt32(0);
                        employee.Name = reader.GetString(1);
                        employee.Gender = reader.GetString(2);
                        employee.phone_Number = reader.GetString(3);
                        employee.Address = reader.GetString(4);
                        employee.Department = reader.GetString(5);
                        employee.BasicPay = reader.GetInt32(6);
                        employee.Deduction = reader.GetDouble(7);
                        employee.TaxablePay = reader.GetDouble(8);
                        employee.Tax = reader.GetDouble(9);
                        employee.NetPay = reader.GetDouble(10);
                        employee.StartDate = reader.GetDateTime(11);
                        //// display the payroll data from database
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} ", employee.ID, employee.Name,
                            employee.Gender, employee.phone_Number, employee.Address, employee.Department, employee.BasicPay, employee.Deduction,
                            employee.TaxablePay, employee.Tax, employee.NetPay, employee.StartDate);
                    }
                }
                else
                {
                    Console.WriteLine("No record found");
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        /// <summary>
        /// Add Multiple Employee Without Thread
        /// </summary>
        /// <param name="empList"></param>
        public void AddMultipleEmployee(List<Employee> empList)
        {
            empList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added:" + employeeData.Name);
                this.AddMultipleEmployee(employeeData);
                Console.WriteLine("Employee added:" + employeeData.Name);
            });
            Console.WriteLine(this.empList.ToString());
        }
        public void AddMultipleEmployee(Employee emp)
        {
            empList.Add(emp);
        }
    }
}