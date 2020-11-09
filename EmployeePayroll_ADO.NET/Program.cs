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
                        EmployeeModel employee = new EmployeeModel();
                        Console.Write("Enter Name :");
                        employee.EmployeeName = Console.ReadLine();
                        Console.Write("Enter Gender :");
                        employee.Gender = Convert.ToChar(Console.ReadLine());
                        Console.Write("Enter Company :");
                        employee.Company = Console.ReadLine();
                        Console.Write("Enter Department :");
                        employee.Department = Console.ReadLine();
                        Console.Write("Enter Phone Number :");
                        employee.PhoneNumber = Console.ReadLine();
                        Console.Write("Enter Address :");
                        employee.Address = Console.ReadLine();
                        Console.Write("Enter Start date :");
                        employee.StartDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter Basic pay :");
                        employee.BasicPay = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Deductions :");
                        employee.Deductions = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Taxable pay :");
                        employee.TaxablePay = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Tax :");
                        employee.Tax = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Net pay :");
                        employee.NetPay = Convert.ToDecimal(Console.ReadLine());
                        if (repo.AddEmployee(employee))
                            Console.WriteLine("Employee details added successfully!");
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
