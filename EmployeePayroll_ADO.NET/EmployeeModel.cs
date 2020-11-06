using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll_ADO.NET
{
    class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public char Gender { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }
    }
}
