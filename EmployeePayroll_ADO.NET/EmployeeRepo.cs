using System;
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
                using (this.connection)
                {
                    string query = @"Select * from Employee";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        // Printing column headers in Employee_Payroll
                        Console.Write("EmpID" + "\t" + "Name" + "\t\t" + "Gender" + "\t " + "Company" + "\t");
                        Console.Write("Department" + "\t" + "PhoneNumber" + "\t" + "Address" + "\t" + "StartDate" + "\t");
                        Console.Write("Basic" + "\t" + "Deductions" + "\t" + "Taxable" + "\t" + "Tax" + "\t" + "NetPay\n");

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
                            Console.Write("{0}\t{1}\t{2}\t{3}\t", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.Gender, employeeModel.Company);
                            Console.Write("{0}\t{1}\t{2}\t{3}\t", employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.StartDate.ToString("dd-mm-yyyy"));
                            Console.Write("{0}\t{1}\t{2}\t", Math.Round(employeeModel.BasicPay, 0), Math.Round(employeeModel.Deductions, 0), Math.Round(employeeModel.TaxablePay, 0));
                            Console.Write("{0}\t{1}", Math.Round(employeeModel.Tax, 0), Math.Round(employeeModel.NetPay, 0));
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
                this.connection.Close();
            }
        }

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
                    command.Parameters.AddWithValue("@Company", model.Company);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
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

        public bool UpdateSalary(string name, decimal salary)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.Parameters.AddWithValue("@BasicPay", salary);
                    this.connection.Open();
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
                this.connection.Close();
            }
            return false;
        }

        public void GetEmployeeByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("spGetEmployeeByName", this.connection);
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.connection.Open();
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
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No record found with name '{0}'",name);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            finally
            {
                this.connection.Close();
            }
        }

        public List<EmployeeModel> GetEmployeesGivenDateRange(DateTime date1, DateTime date2)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                List<EmployeeModel> employeeList = new List<EmployeeModel>();
                SqlCommand command = new SqlCommand("SpGetEmployeesByStartDateRange", this.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StartDate1", date1);
                command.Parameters.AddWithValue("@StartDate2", date2);
                this.connection.Open();

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    // Printing column headers in Employee_Payroll
                    Console.Write("EmpID" + "\t" + "Name" + "\t\t" + "Gender" + "\t " + "Company" + "\t");
                    Console.Write("Department" + "\t" + "PhoneNumber" + "\t" + "Address" + "\t" + "StartDate" + "\t");
                    Console.Write("Basic" + "\t" + "Deductions" + "\t" + "Taxable" + "\t" + "Tax" + "\t" + "NetPay\n");

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

                        Console.Write("{0}\t{1}\t{2}\t{3}\t", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.Gender, employeeModel.Company);
                        Console.Write("{0}\t{1}\t{2}\t{3}\t", employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.StartDate.ToString("dd-mm-yyyy"));
                        Console.Write("{0}\t{1}\t{2}\t", Math.Round(employeeModel.BasicPay, 0), Math.Round(employeeModel.Deductions, 0), Math.Round(employeeModel.TaxablePay, 0));
                        Console.Write("{0}\t{1}", Math.Round(employeeModel.Tax, 0), Math.Round(employeeModel.NetPay, 0));
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
                this.connection.Close();
            }
            return null;
        }
    }
}



