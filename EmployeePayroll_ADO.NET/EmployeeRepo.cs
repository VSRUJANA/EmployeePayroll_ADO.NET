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

        public DataSet GetAllEmployee()
        {
            try
            {
                DataSet dataset = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Close();
                    return dataset;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
