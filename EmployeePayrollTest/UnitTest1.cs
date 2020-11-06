using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeePayroll_ADO.NET;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenNameAndUpdatedSalary_UpdateSalaryMethod_ShouldReturnTrue()
        {
            EmployeeRepo repo = new EmployeeRepo();
            bool updateResult = repo.UpdateSalary("Jennifer", Convert.ToDecimal("250000"));
            bool expected = true;
            Assert.AreEqual(updateResult, expected);
        }

        [TestMethod]
        public void GivenDateRange_ShouldReturnListOfEmployeesWithStartingDateWithinRange()
        {
            EmployeeRepo repo = new EmployeeRepo();
            DateTime date1 = new DateTime(2018, 1, 15);
            DateTime date2 = new DateTime(2020, 11, 10);
            List<EmployeeModel> actual=repo.GetEmployeesGivenDateRange(date1, date2);
            Assert.AreEqual(actual.Count(), 4);
        }
    }
}
