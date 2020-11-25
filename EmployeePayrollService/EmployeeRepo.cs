using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        /// <summary>
        /// Ability to create a payroll service database and have java program connect to database
        /// </summary>
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        /// <summary>
        /// Ability for Employee Payroll Service to retrieve the Employee Payroll from the Database
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
        /// Ability to update the salary i.e. the base pay for Employee Terisa to 3000000.00 and sync it with Database using ADO.NET ConnectionString
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        public int UpdateEmployeeSalary(SalaryUpdateModel updateModel)
        {
            int salary = 0;
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", sqlconnection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SalaryId", updateModel.SalaryId);
                    command.Parameters.AddWithValue("@SalaryMonth", updateModel.SalaryMonth);
                    command.Parameters.AddWithValue("@Salary", updateModel.Salary);
                    command.Parameters.AddWithValue("@EmpId", updateModel.EmpId);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmpId = Convert.ToInt32(sqlDataReader["EmpId"]);
                            employeeModel.EmpName = sqlDataReader["EmpName"].ToString();
                            employeeModel.SalaryMonth = sqlDataReader["SalaryMonth"].ToString();
                            employeeModel.Salary = Convert.ToInt32(sqlDataReader["Salary"]);
                            employeeModel.SalaryId = Convert.ToInt32(sqlDataReader["SalaryId"]);

                            Console.WriteLine("{0},{1},{2},{3},{4}",
                                employeeModel.EmpId, employeeModel.EmpName, employeeModel.SalaryMonth,
                                employeeModel.Salary, employeeModel.SalaryId);
                            salary = (int)employeeModel.Salary;
                        }
                    }
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
            return salary;
        }

        /// <summary>
        /// Ability to retrieve all employees who have joined in a particular data range from the payroll service database
        /// </summary>
        public void GetAllEmployeeInADataRange()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT * FROM Employee_Payroll WHERE Start_Date between cast('2019-01-01' AS DATE) and SYSDATETIME();";
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
        /// Ability to find sum, average, min, max and number of male and female employees
        /// </summary>
        public void GetDataByGroupByGender()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT Gender,COUNT(Salary),
                                    SUM(Salary),MAX(Salary),MIN(Salary)FROM Employee_Payroll 
                                    GROUP BY Gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            string Gender = sqlDataReader.GetString(0);
                            int COUNT = sqlDataReader.GetInt32(1);
                            double SUM = (double)sqlDataReader.GetDecimal(2);
                            double MAX = (double)sqlDataReader.GetDecimal(3);
                            double MIN = (double)sqlDataReader.GetDecimal(4);

                            Console.WriteLine("Gender: " + Gender + "\nCount: " + COUNT + "\nSum: " + SUM +
                                "\nMax: " + MAX + "\nMin: " + MIN);
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
        /// Ability to add a new Employee to the Payroll
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("SpAddEmployee", this.sqlconnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmpId", employeeModel.EmpId);
                    sqlCommand.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                    sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employeeModel.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employeeModel.Phone_Number);
                    sqlCommand.Parameters.AddWithValue("@Employee_Address", employeeModel.Employee_Address);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employeeModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employeeModel.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_Pay", employeeModel.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", employeeModel.Net_Pay);

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

        /// <summary>
        /// Ability to remove Employee from the Payroll
        /// </summary>
        /// <returns></returns>
        public bool RemoveEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"DELETE FROM Employee_Payroll 
                                    WHERE EmpId=6;";

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

        /// <summary>
        /// Get all Employee Details from Employee table
        /// </summary>
        public void GetAllEmployeeDetails()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT * FROM Employee;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmpId = sqlDataReader.GetInt32(0);
                            employeeModel.EmpName = sqlDataReader.GetString(1);
                            employeeModel.Employee_Address = sqlDataReader.GetString(2);
                            employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(3));
                            employeeModel.Phone_Number = sqlDataReader.GetString(4);

                            Console.WriteLine("Employee Id: " + employeeModel.EmpId + "\nEmployee Name: " + employeeModel.EmpName +
                                "\nEmployee Address: " + employeeModel.Employee_Address + 
                                "\nGender: " + employeeModel.Gender+"\nPhone Number:"+employeeModel.Phone_Number);
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
        /// Get Depatment details from Department table
        /// </summary>
        public void GetAllDepartment()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT * FROM Department;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmpId = sqlDataReader.GetInt32(0);
                            employeeModel.DeptId = sqlDataReader.GetInt32(1);
                            employeeModel.DeptName = sqlDataReader.GetString(2);
                            employeeModel.DeptLocation = sqlDataReader.GetString(3);

                            Console.WriteLine("EmpId: " + employeeModel.EmpId + "\nDeptId: " + employeeModel.DeptId + 
                                "\nDeptName: " + employeeModel.DeptName +"\nDeptLocation: " + employeeModel.DeptLocation);
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
        /// Get Employee Salary from Salary table
        /// </summary>
        public void GetEmployeeSalary()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT * FROM Salary;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmpId = sqlDataReader.GetInt32(0);
                            employeeModel.SalaryId = sqlDataReader.GetInt32(1);
                            employeeModel.Salary = (double)sqlDataReader.GetDecimal(2);
                            employeeModel.Basic_Pay = (double)sqlDataReader.GetDecimal(3);
                            employeeModel.Deductions = (double)sqlDataReader.GetDecimal(4);
                            employeeModel.Taxable_Pay = (double)sqlDataReader.GetDecimal(5);
                            employeeModel.Income_Tax = (double)sqlDataReader.GetDecimal(6);
                            employeeModel.Net_Pay = (double)sqlDataReader.GetDecimal(7);
                            employeeModel.SalaryMonth = sqlDataReader.GetString(8);

                            Console.WriteLine("EmpId: " + employeeModel.EmpId + "\nSalaryId: " + employeeModel.Salary +
                                "\nBasic Pay:" + employeeModel.Basic_Pay + "\nDeductions:" + employeeModel.Deductions +
                                "\nTaxable Pay:" + employeeModel.Taxable_Pay + "\nIncome Pay:" + employeeModel.Income_Tax +
                                "\nNet Pay:" + employeeModel.Net_Pay + "\nSalary Month" + employeeModel.SalaryMonth);
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
        /// Get data by Gender using Join
        /// </summary>
        public void GetDataByGroupByGenderER()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"SELECT Gender,COUNT(Salary),
                                    SUM(Salary),MAX(Salary),MIN(Salary)
                                    FROM Salary INNER JOIN Employee 
                                    ON Salary.EmpId=Employee.EmpId
                                    WHERE Gender='F' GROUP BY Gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);

                    this.sqlconnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            string Gender = sqlDataReader.GetString(0);
                            int COUNT = sqlDataReader.GetInt32(1);
                            double SUM = (double)sqlDataReader.GetDecimal(2);
                            double MAX = (double)sqlDataReader.GetDecimal(3);
                            double MIN = (double)sqlDataReader.GetDecimal(4);

                            Console.WriteLine("Gender: " + Gender + "\nCount: " + COUNT + "\nSum: " + SUM +
                                "\nMax: " + MAX + "\nMin: " + MIN);
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
    }
}
