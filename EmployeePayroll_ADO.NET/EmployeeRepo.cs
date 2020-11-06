using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll_ADO.NET
{
    class EmployeeRepo
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
                        Console.Write("Department" + "\t" + "PhoneNumber" + "\t" + "Address" + "\t\t" + "StartDate" + "\t");
                        Console.Write("Basic" + "  " + "Deductions" + "  " + "Taxable" + "   " + "Tax" + "   " + "NetPay\n");
                        
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(2));
                            employeeModel.Company = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.StartDate = dr.GetDateTime(7);
                            employeeModel.BasicPay = dr.GetDecimal(8);
                            employeeModel.Deductions = dr.GetDecimal(9);
                            employeeModel.TaxablePay = dr.GetDecimal(10);
                            employeeModel.Tax = dr.GetDecimal(11);
                            employeeModel.NetPay = dr.GetDecimal(12);

                            // Printing Employee_payroll data
                            Console.Write("{0}\t{1}\t{2}\t{3}\t", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.Gender, employeeModel.Company);
                            Console.Write("{0}\t{1}\t{2}\t{3}", employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.StartDate.ToString("dd-mm-yyyy"));
                            Console.Write("\t{0}\t{1} \t {2}", Math.Round(employeeModel.BasicPay, 0), Math.Round(employeeModel.Deductions, 0), Math.Round(employeeModel.TaxablePay, 0));
                            Console.Write("\t {0} \t{1}", Math.Round(employeeModel.Tax, 0), Math.Round(employeeModel.NetPay, 0));
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
    }
}
