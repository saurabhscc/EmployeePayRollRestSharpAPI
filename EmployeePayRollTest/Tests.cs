using EmployeePayRoll;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmployeePayRollTest
{
    public class Tests
    {
        EmployeeOperation employeeOperation = new EmployeeOperation();
        [Test]
        public void GivenEmployeeDetail_ShouldMatchWithUpdatedDetails()
        {
            int expected = 2;
            int actual = employeeOperation.UpdateEmployeeSalary();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// UC1-Add Multiple Employee without threads
        /// </summary>
        [Test]
        public void Given10Employee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee(1, "sai", "M", "5656565656", "Pune", "Operations", 4000, 100.0, 100.0, 100.0, 3700.00, DateTime.Today));
            list.Add(new Employee(2, "shree", "M", "7777666677", "Mumbai", "Research", 4500, 150, 250.0, 150.0, 3950.0, DateTime.Today));
            list.Add(new Employee(3, "Abhi", "M", "9988998877", "Mumbai", "Maintenance", 4100, 150.0, 150.0, 100.0, 3700.00, DateTime.Today));
            list.Add(new Employee(4, "Nitesh", "M", "5253565656", "Pune", "Operations", 4000, 100.0, 100.0, 100.0, 3700.00, DateTime.Today));
            list.Add(new Employee(5, "Rahul", "M", "6666666677", "Mumbai", "HR", 4500, 150, 250.0, 150.0, 3950.0, DateTime.Today));
            list.Add(new Employee(6, "Gaurav", "M", "9988998866", "Mumbai", "Maintenance", 4100, 150.0, 150.0, 100.0, 3700.00, DateTime.Today));
            list.Add(new Employee(7, "Abhishek", "M", "5656565655", "Pune", "HR", 4000, 100.0, 100.0, 100.0, 3700.00, DateTime.Today));
            list.Add(new Employee(8, "shreetej", "M", "7777666676", "Thane", "Research", 4500, 150, 250.0, 150.0, 3950.0, DateTime.Today));
            list.Add(new Employee(9, "samarth", "M", "7777666600", "Mumbai", "Maintenance", 4500, 150, 250.0, 150.0, 3950.0, DateTime.Today));
            list.Add(new Employee(10, "Ajay", "M", "5656565655", "Pune", "Research", 4000, 100.0, 100.0, 100.0, 3700.00, DateTime.Today));
            DateTime startDateTime = DateTime.Now;
            employeeOperation.AddMultipleEmployee(list);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread" + (startDateTime - stopDateTime));

        }
    }
}