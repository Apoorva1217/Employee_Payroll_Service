using System;
using System.Collections.Generic;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            SalaryUpdateModel updateModel = new SalaryUpdateModel();
            
            ///Get All Employee present in Employee_Payroll table
            //employeeRepo.GetAllEmployee();
            ///Update Employee Salary
            //employeeRepo.UpdateEmployeeSalary(updateModel);
            ///Get All Employee in a particular data range
            //employeeRepo.GetAllEmployeeInADataRange();
            ///Get data by Gender
            //employeeRepo.GetDataByGroupByGender();
            
            ///Add Employee Details
            employeeModel.EmpName = "Appu";
            employeeModel.Salary = 500000.00;
            employeeModel.Start_Date = Convert.ToDateTime("12/05/2020");
            employeeModel.Gender = 'F';
            employeeModel.Phone_Number = "9877553212";
            employeeModel.Employee_Address = "Kharadi";
            employeeModel.Department = "Tetsing";
            employeeModel.Basic_Pay = 8765.00;
            employeeModel.Deductions = 9876.00;
            employeeModel.Taxable_Pay = 97765.00;
            employeeModel.Income_Tax = 7654.00;
            employeeModel.Net_Pay = 6543.00;
            employeeModel.EmpId = 6;
            employeeModel.DeptId = 7;
            employeeModel.DeptName = "Development";
            employeeModel.DeptLocation = "Pune";
            employeeModel.SalaryMonth = "Jan";
            
            ///Add Employee in Employee_Payroll table
            //employeeRepo.AddEmployee(employeeModel);
            ///Remove particular employee entry using EmpId
            //employeeRepo.RemoveEmployee();
            ///Get Employee Details present in Employee table
            //employeeRepo.GetAllEmployeeDetails();
            ///Get Department details from Department table
            //employeeRepo.GetAllDepartment();
            ///Get Salary of Employee from Salary table
            //employeeRepo.GetEmployeeSalary();
            ///Get Data by Gender using joins
            //employeeRepo.GetDataByGroupByGenderER();

            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            List<EmployeeModel> employeePayrollDataList = new List<EmployeeModel>();
            employeePayrollOperations.AddEmployeeToPayroll(employeePayrollDataList);
        }
    }
}
