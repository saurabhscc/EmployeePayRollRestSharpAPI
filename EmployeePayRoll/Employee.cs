using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRoll
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string phone_Number { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public Employee()
        {
        }
        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="City"></param>
        public Employee(int ID, string Name, string Gender, string PhoneNumber, string Address, string Department, int BasicPay,
                        double Deduction, double TaxablePay, double Tax, double NetPay, DateTime StartDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.phone_Number = PhoneNumber;
            this.Address = Address;
            this.Department = Department;
            this.BasicPay = BasicPay;
            this.Deduction = Deduction;
            this.TaxablePay = TaxablePay;
            this.Tax = Tax;
            this.NetPay = NetPay;
            this.StartDate = StartDate;

        }
    }
}