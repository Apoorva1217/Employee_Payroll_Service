using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        /// <summary>
        /// UC1 Ability to create a payroll service database and have java program connect to database
        /// </summary>
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        readonly SqlConnection sqlconnection = new SqlConnection(connectionString);

        /// <summary>
        /// UC2 Ability for Employee Payroll Service to retrieve the Employee Payroll from the Database
        /// </summary>
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT EmpId,EmpName,Salary,Start_Date,
                                    Gender,Phone_Number,Employee_Address,Department,
                                    Basic_Pay,Deductions,Taxable_Pay,Income_Tax,Net_Pay 
                                    FROM Employee_Payroll;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmpId = sqlDataReader.GetInt32(0);
                            employeeModel.EmpName = sqlDataReader.GetString(1);
                            employeeModel.Salary = (double)sqlDataReader.GetDecimal(2);
                            employeeModel.Start_Date = sqlDataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(4));
                            employeeModel.Phone_Number = sqlDataReader.GetString(5);
                            employeeModel.Employee_Address = sqlDataReader.GetString(6);
                            employeeModel.Department = sqlDataReader.GetString(7);
                            employeeModel.Basic_Pay = (double)sqlDataReader.GetDecimal(8);
                            employeeModel.Deductions = (double)sqlDataReader.GetDecimal(9);
                            employeeModel.Taxable_Pay = (double)sqlDataReader.GetDecimal(10);
                            employeeModel.Income_Tax = (double)sqlDataReader.GetDecimal(11);
                            employeeModel.Net_Pay = (double)sqlDataReader.GetDecimal(12);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                                employeeModel.EmpId, employeeModel.EmpName, employeeModel.Salary,
                                employeeModel.Start_Date, employeeModel.Gender, employeeModel.Phone_Number,
                                employeeModel.Employee_Address, employeeModel.Department, employeeModel.Basic_Pay,
                                employeeModel.Deductions, employeeModel.Taxable_Pay, employeeModel.Income_Tax,
                                employeeModel.Net_Pay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    sqlDataReader.Close();
                    this.sqlconnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }

        /// <summary>
        /// UC3 Ability to update the salary i.e. the base pay for Employee Terisa to 3000000.00 and sync it with Database
        /// </summary>
        public bool UpdateEmployeeSalary(string EmpName)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"UPDATE Employee_Payroll SET Basic_Pay=3000000.00 WHERE EmpName='" + EmpName + "';";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);
                    this.sqlconnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlconnection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }
}
