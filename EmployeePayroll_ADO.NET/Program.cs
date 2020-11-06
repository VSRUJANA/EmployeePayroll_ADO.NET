using System;

namespace EmployeePayroll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            //repo.UpdateSalary("Jennifer",250000);
            //repo.GetAllEmployee();
            //repo.GetEmployeeByName("Jennifer");
            //DateTime date1 = new DateTime(2018, 1, 15);
            //DateTime date2 = new DateTime(2020, 11, 10);
            //repo.GetEmployeesGivenDateRange(date1, date2);
            repo.SumOfSalaryGenderWise();
            repo.AverageOfSalaryGenderWise();
            repo.MinimumSalaryGenderWise();
            repo.MaximumSalaryGenderWise();
            repo.CountOfEmployeesGenderWise();
        }
    }
}
