using System;

namespace EmployeePayroll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            if (repo.GetAllEmployee() != null)
                Console.WriteLine("Connection Established!");
        }
    }
}
