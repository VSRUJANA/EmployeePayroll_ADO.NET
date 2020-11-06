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
            repo.GetEmployeeByName("Jennifer");
        }
    }
}
