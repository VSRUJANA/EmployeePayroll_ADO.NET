﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll_ADO.NET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=LAPTOP-BSJLU8TT\SQLEXPRESS;Initial Catalog=Payroll_ServiceDB;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        // Method to retrieve the Employee Payroll from the Database
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select * from Employee";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        // Printing column headers in Employee_Payroll
                        Console.Write("ID  " + " Name  " + " Gender  " + " Company" + "\t");
                        Console.Write("Department  " + " PhoneNo. " + "  Address" + "     " + "StartDate");
                        Console.Write("  Basic " + "Deductions " + "Taxable  " + "Tax  " + " NetPay\n");
                        Console.Write("------------------------------------------------------------------------------------------------------------------------");

                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = !dr.IsDBNull(1) ? dr.GetString(1) : "NA";
                            employeeModel.Gender = !dr.IsDBNull(2) ? Convert.ToChar(dr.GetString(2)) : 'N';
                            employeeModel.Company = !dr.IsDBNull(3) ? dr.GetString(3) : "NA";
                            employeeModel.Department = !dr.IsDBNull(4) ? dr.GetString(4) : "NA";
                            employeeModel.PhoneNumber = !dr.IsDBNull(5) ? dr.GetString(5) : "NA";
                            employeeModel.Address = !dr.IsDBNull(6) ? dr.GetString(6) : "NA";
                            employeeModel.StartDate = !dr.IsDBNull(7) ? dr.GetDateTime(7) : DateTime.MinValue;
                            employeeModel.BasicPay = !dr.IsDBNull(8) ? dr.GetDecimal(8) : 0;
                            employeeModel.Deductions = !dr.IsDBNull(9) ? dr.GetDecimal(9) : 0;
                            employeeModel.TaxablePay = !dr.IsDBNull(10) ? dr.GetDecimal(10) : 0;
                            employeeModel.Tax = !dr.IsDBNull(11) ? dr.GetDecimal(11) : 0;
                            employeeModel.NetPay = !dr.IsDBNull(12) ? dr.GetDecimal(12) : 0;

                            // Printing Employee_payroll data
                            Console.Write(employeeModel.EmployeeID.ToString().PadRight(3)+ employeeModel.EmployeeName.PadRight(12) + employeeModel.Gender + "   " + employeeModel.Company.PadRight(12));
                            Console.Write(employeeModel.Department.PadRight(12) + employeeModel.PhoneNumber.PadRight(12) + employeeModel.Address.PadRight(12) + employeeModel.StartDate.ToString("dd-MM-yyyy").PadRight(12));
                            Console.Write(Math.Round(employeeModel.BasicPay, 0) + "\t" + Math.Round(employeeModel.Deductions, 0) + "\t" + Math.Round(employeeModel.TaxablePay, 0) + "\t");
                            Console.Write(Math.Round(employeeModel.Tax, 0) + "\t" + Math.Round(employeeModel.NetPay, 0));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }
        }

        // Method to update Salary of particular employee
        public bool UpdateSalary(string name, decimal salary)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.Parameters.AddWithValue("@BasicPay", salary);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Salary of record with name '{0}' updated successfully", name);
                        return true;
                    }
                    Console.WriteLine("No record with name '{0}' found", name);
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        // Method to get Employee details by name
        public void GetEmployeeByName(string name)
        {
            connection = new SqlConnection(connectionString);
            try
            {

                EmployeeModel employeeModel = new EmployeeModel();
                SqlCommand command = new SqlCommand("spGetEmployeeByName", connection);
                command.Parameters.AddWithValue("@EmployeeName", name);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeeModel.EmployeeID = dr.GetInt32(0);
                        employeeModel.EmployeeName = !dr.IsDBNull(1) ? dr.GetString(1) : "NA";
                        employeeModel.Gender = !dr.IsDBNull(2) ? Convert.ToChar(dr.GetString(2)) : 'N';
                        employeeModel.Company = !dr.IsDBNull(3) ? dr.GetString(3) : "NA";
                        employeeModel.Department = !dr.IsDBNull(4) ? dr.GetString(4) : "NA";
                        employeeModel.PhoneNumber = !dr.IsDBNull(5) ? dr.GetString(5) : "NA";
                        employeeModel.Address = !dr.IsDBNull(6) ? dr.GetString(6) : "NA";
                        employeeModel.StartDate = !dr.IsDBNull(7) ? dr.GetDateTime(7) : DateTime.MinValue;
                        employeeModel.BasicPay = !dr.IsDBNull(8) ? dr.GetDecimal(8) : 0;
                        employeeModel.Deductions = !dr.IsDBNull(9) ? dr.GetDecimal(9) : 0;
                        employeeModel.TaxablePay = !dr.IsDBNull(10) ? dr.GetDecimal(10) : 0;
                        employeeModel.Tax = !dr.IsDBNull(11) ? dr.GetDecimal(11) : 0;
                        employeeModel.NetPay = !dr.IsDBNull(12) ? dr.GetDecimal(12) : 0;

                        // Printing Employee_payroll data
                        Console.WriteLine("Payroll data of {0} : ", name);
                        Console.WriteLine("Employee ID   : " + employeeModel.EmployeeID);
                        Console.WriteLine("Employee Name : " + employeeModel.EmployeeName);
                        Console.WriteLine("Gender        : " + employeeModel.Gender);
                        Console.WriteLine("Company       : " + employeeModel.Company);
                        Console.WriteLine("Department    : " + employeeModel.Department);
                        Console.WriteLine("Phone Number  : " + employeeModel.PhoneNumber);
                        Console.WriteLine("Address       : " + employeeModel.Address);
                        Console.WriteLine("Start Date    : " + employeeModel.StartDate.ToString("dd-mm-yyyy"));
                        Console.Write("Basic Pay : " + Math.Round(employeeModel.BasicPay, 0) + "\tDeductions : " + Math.Round(employeeModel.Deductions, 0));
                        Console.Write("\tTaxable Pay : " + Math.Round(employeeModel.TaxablePay, 0) + "\tIncome Tax : " + Math.Round(employeeModel.Tax, 0));
                        Console.Write("\tNet Pay : " + Math.Round(employeeModel.NetPay, 0));
                        Console.Write("\n");
                    }
                }
                else
                {
                    System.Console.WriteLine("No record found with name '{0}'", name);
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }
        }

        // Method to get all employees who joined in the given date range
        public List<EmployeeModel> GetEmployeesGivenDateRange(DateTime date1, DateTime date2)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                if (date1 > date2)
                    throw new Exception("Start date cannot be greater than End date!");
                EmployeeModel employeeModel = new EmployeeModel();
                List<EmployeeModel> employeeList = new List<EmployeeModel>();
                SqlCommand command = new SqlCommand("SpGetEmployeesByStartDateRange", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StartDate1", date1);
                command.Parameters.AddWithValue("@StartDate2", date2);
                connection.Open();

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("List of Employees who joined between {0} and {1} : \n", date1.ToString("dd-mm-yyyy"), date2.ToString("dd-mm-yyyy"));
                    // Printing column headers in Employee_Payroll
                    Console.Write("ID  " + " Name  " + " Gender  " + " Company" + "\t");
                    Console.Write("Department  " + " PhoneNo. " + "  Address" + "     " + "StartDate");
                    Console.Write("  Basic " + "Deductions " + "Taxable  " + "Tax  " + " NetPay\n");
                    Console.Write("------------------------------------------------------------------------------------------------------------------------");

                    while (dr.Read())
                    {
                        employeeModel.EmployeeID = dr.GetInt32(0);
                        employeeModel.EmployeeName = !dr.IsDBNull(1) ? dr.GetString(1) : "NA";
                        employeeModel.Gender = !dr.IsDBNull(2) ? Convert.ToChar(dr.GetString(2)) : 'N';
                        employeeModel.Company = !dr.IsDBNull(3) ? dr.GetString(3) : "NA";
                        employeeModel.Department = !dr.IsDBNull(4) ? dr.GetString(4) : "NA";
                        employeeModel.PhoneNumber = !dr.IsDBNull(5) ? dr.GetString(5) : "NA";
                        employeeModel.Address = !dr.IsDBNull(6) ? dr.GetString(6) : "NA";
                        employeeModel.StartDate = !dr.IsDBNull(7) ? dr.GetDateTime(7) : DateTime.MinValue;
                        employeeModel.BasicPay = !dr.IsDBNull(8) ? dr.GetDecimal(8) : 0;
                        employeeModel.Deductions = !dr.IsDBNull(9) ? dr.GetDecimal(9) : 0;
                        employeeModel.TaxablePay = !dr.IsDBNull(10) ? dr.GetDecimal(10) : 0;
                        employeeModel.Tax = !dr.IsDBNull(11) ? dr.GetDecimal(11) : 0;
                        employeeModel.NetPay = !dr.IsDBNull(12) ? dr.GetDecimal(12) : 0;
                        employeeList.Add(employeeModel);

                        // Printing Employee_payroll data
                        Console.Write(employeeModel.EmployeeID + "   " + employeeModel.EmployeeName.PadRight(12) + employeeModel.Gender + "   " + employeeModel.Company.PadRight(12));
                        Console.Write(employeeModel.Department.PadRight(12) + employeeModel.PhoneNumber.PadRight(12) + employeeModel.Address.PadRight(12) + employeeModel.StartDate.ToString("dd-mm-yyyy").PadRight(12));
                        Console.Write(Math.Round(employeeModel.BasicPay, 0) + "\t" + Math.Round(employeeModel.Deductions, 0) + "\t" + Math.Round(employeeModel.TaxablePay, 0) + "\t");
                        Console.Write(Math.Round(employeeModel.Tax, 0) + "\t" + Math.Round(employeeModel.NetPay, 0));
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No employee joinings found in the given data range");
                }
                return employeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        // Method to find Sum of salaries gender wise
        public void SumOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, SUM(BasicPay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("Sum of salaries genderwise :");
                        Console.WriteLine(" Gender\t Sum");
                        while (dr.Read())
                        {
                            Console.Write("  " + dr.GetString(0) + "\t" + dr.GetDecimal(1));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Method to find Average of salaries gender wise
        public void AverageOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, AVG(BasicPay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("Average of salaries genderwise :");
                        Console.WriteLine(" Gender\t Average");
                        while (dr.Read())
                        {
                            Console.Write("  " + dr.GetString(0) + "\t" + dr.GetDecimal(1));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Method to find Minimum salary gender wise
        public void MinimumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, MIN(BasicPay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("Minimum salary genderwise :");
                        Console.WriteLine(" Gender\t Minimum Salary");
                        while (dr.Read())
                        {
                            Console.Write("  " + dr.GetString(0) + "\t" + dr.GetDecimal(1));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Method to find Maximum salary gender wise
        public void MaximumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, MAX(BasicPay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("Maximum salary genderwise :");
                        Console.WriteLine(" Gender\t Maximum Salary");
                        while (dr.Read())
                        {
                            Console.Write("  " + dr.GetString(0) + "\t" + dr.GetDecimal(1));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Method to find count of employees gender wise
        public void CountOfEmployeesGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, COUNT(gender) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("Employee count genderwise :");
                        Console.WriteLine(" Gender\t Count");
                        while (dr.Read())
                        {
                            Console.Write("  " + dr.GetString(0) + "\t  " + dr.GetInt32(1));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Method to add new employee to the database
        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Company_Name", model.Company);
                    command.Parameters.AddWithValue("@Dept_Name", model.Department);
                    command.Parameters.AddWithValue("@Phone_No", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@start_date", model.StartDate);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        // Method to add derived payroll details when new Employee is added to the Employee_Payroll
        public bool AddDerivedPayrollFields(string employeeName, char gender, string company, string department, string phoneNumber, string address, DateTime startDate, decimal basicPay)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int employeeAdded = 0;
            int payrollAdded = 0;
            try
            {
                using (connection)
                { 
                    EmployeeModel model = new EmployeeModel();
                    model.EmployeeName = employeeName;
                    model.Gender = gender;
                    model.Company = company;
                    model.Department = department;
                    model.PhoneNumber = phoneNumber;
                    model.Address = address;
                    model.StartDate = startDate;
                    model.BasicPay = basicPay;
                    string addEmployeeQuery = "INSERT INTO Employee_payroll VALUES(@Emp_Name,@gender,@Company_Name,@Dept_Name,@phoneNumber,@address,@startDate,@basicPay)";
                    SqlCommand addEmployeeCmd = new SqlCommand(addEmployeeQuery, connection);
                    using (addEmployeeCmd)
                    {
                        // define parameters and their values
                        addEmployeeCmd.Parameters.Add("@Emp_Name", SqlDbType.VarChar).Value = employeeName;
                        addEmployeeCmd.Parameters.Add("@gender", SqlDbType.Char).Value = gender;
                        addEmployeeCmd.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = company;
                        addEmployeeCmd.Parameters.Add("@Dept_Name", SqlDbType.VarChar).Value = department;
                        addEmployeeCmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = phoneNumber;
                        addEmployeeCmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                        addEmployeeCmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                        addEmployeeCmd.Parameters.Add("@basicPay", SqlDbType.Decimal).Value = basicPay;

                        // open connection, execute INSERT, close connection
                        connection.Open();
                        employeeAdded = addEmployeeCmd.ExecuteNonQuery();
                        connection.Close();
                    }

                    // Calculate derived payroll details
                    model.Deductions = 0.2m * basicPay;
                    model.TaxablePay = basicPay - model.Deductions;
                    model.Tax = 0.1m * model.TaxablePay;
                    model.NetPay = model.TaxablePay - model.Tax;

                    string addPayrollQuery = @"INSERT INTO payroll_detail VALUES(@basic_Pay,@deduction,@taxablePay,@incomeTax,@netPay)";
                    SqlCommand addPayrollCmd = new SqlCommand(addPayrollQuery, connection);
                    using (addPayrollCmd)
                    {
                        addPayrollCmd.Parameters.Add("@basic_Pay", SqlDbType.Decimal).Value = basicPay;
                        addPayrollCmd.Parameters.Add("@deduction", SqlDbType.Decimal).Value = model.Deductions;
                        addPayrollCmd.Parameters.Add("@taxablePay", SqlDbType.Decimal).Value = model.TaxablePay;
                        addPayrollCmd.Parameters.Add("@incomeTax", SqlDbType.Decimal).Value = model.Tax;
                        addPayrollCmd.Parameters.Add("@netPay", SqlDbType.Decimal).Value = model.NetPay;

                        // open connection, execute INSERT, close connection
                        connection.Open();
                        payrollAdded = addPayrollCmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    if (employeeAdded == 1 && payrollAdded == 1)
                    {
                        AddEmployee(model);
                        Console.WriteLine("Record added successfully");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}