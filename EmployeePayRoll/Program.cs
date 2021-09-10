using System;
using System.Collections.Generic;

namespace EmployeePayRoll
{
    namespace EmployeePayroll
    {
        /// <summary>
        /// main class
        /// </summary>
        class Program
        {
            static List<Employee> empList = new List<Employee>();
            static EmployeeOperation employeeOperation = new EmployeeOperation();
            /// <summary>
            /// invoke the EmployeeOperation methods.
            /// </summary>
            public static void DisplayEmployeeDetails()
            {
                empList = employeeOperation.GetAllEmployeeDetails();
                if (empList.Count > 0)
                {
                    foreach (Employee emp in empList)
                    {
                        Console.WriteLine(emp.ID + " " + emp.Name + " " + emp.Gender + " " + emp.phone_Number + emp.Address + " "
                            + emp.Department + " " + emp.BasicPay + " " + emp.Deduction + " " + emp.TaxablePay + " " + emp.Tax + " "
                            + emp.NetPay + " " + emp.StartDate);
                    }
                }
            }
            /// <summary>
            /// main method
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to Employee Payroll ");
            }
        }
    }
}