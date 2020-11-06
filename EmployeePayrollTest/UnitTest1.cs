using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeePayroll_ADO.NET;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenNameAndUpdatedSalary_UpdateSalaryMethod_ShouldReturnTrue()
        {
            EmployeeRepo repo = new EmployeeRepo();
            bool updateResult = repo.UpdateSalary("Jennifer", Convert.ToDecimal("230000"));
            bool expected = true;
            Assert.AreEqual(updateResult, expected);
        }
    }
}
