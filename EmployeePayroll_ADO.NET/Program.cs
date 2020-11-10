using System;

namespace EmployeePayroll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            Console.WriteLine("Menu :");
            Console.Write("1. Retrieve all employees\n2. Retrieve Employee by Name\n3. Update salary of given employee\n");
            Console.Write("4. Retrieve employees in given start date range\n5. Sum of basic pay gender wise \n");
            Console.Write("6. Average of basic pay gender wise \n7. Minimum basic pay gender wise \n8. Maximum basic pay gender wise\n");
            Console.WriteLine("9. Count of employees gender wise\n10.Add New Employee\n11.Exit ");
            while (true)
            {
                Console.Write("Enter your choice :");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.GetAllEmployee();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 2:
                        Console.Write("Enter name :");
                        string name = Console.ReadLine();
                        repo.GetEmployeeByName(name);
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 3:
                        Console.Write("Enter name :");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter updated Basic pay :");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        repo.UpdateSalary(updateName, salary);
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 4:
                        Console.Write("Enter Start date :");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter End date :");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        repo.GetEmployeesGivenDateRange(startDate, endDate);
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 5:
                        repo.SumOfSalaryGenderWise();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 6:
                        repo.AverageOfSalaryGenderWise();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 7:
                        repo.MinimumSalaryGenderWise();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 8:
                        repo.MaximumSalaryGenderWise();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 9:
                        repo.CountOfEmployeesGenderWise();
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 10:
                        Console.Write("Enter Name :");
                        string employeeName = Console.ReadLine();
                        Console.Write("Enter Gender :");
                        char gender = Convert.ToChar(Console.ReadLine());
                        Console.Write("Enter Company :");
                        string company = Console.ReadLine();
                        Console.Write("Enter Department :");
                        string department = Console.ReadLine();
                        Console.Write("Enter Phone Number :");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Address :");
                        string address = Console.ReadLine();
                        Console.Write("Enter Start date :");
                        DateTime startdate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter Basic pay :");
                        decimal basicPay = Convert.ToDecimal(Console.ReadLine());
                        repo.AddDerivedPayrollFields(employeeName,gender,company,department,phoneNumber,address,startdate,basicPay);
                        Console.Write("________________________________________________________________________________________________________________________");
                        break;
                    case 11:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
