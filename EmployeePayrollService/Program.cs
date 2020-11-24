using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            
            //employeeRepo.GetAllEmployee();
            //employeeRepo.GetAllEmployeeInADataRange();
            //employeeRepo.GetDataByGroupByGender();

            employeeModel.EmpName = "Appu";
            employeeModel.Salary = 500000.00;
            employeeModel.Start_Date = Convert.ToDateTime("12/05/2020");
            employeeModel.Gender = 'F';
            employeeModel.Phone_Number = "9876543212";
            employeeModel.Employee_Address = "Kharadi";
            employeeModel.Department = "Tetsing";
            employeeModel.Basic_Pay = 8765.00;
            employeeModel.Deductions = 9876.00;
            employeeModel.Taxable_Pay = 97765.00;
            employeeModel.Income_Tax = 7654.00;
            employeeModel.Net_Pay = 6543.00;

            employeeRepo.AddEmployee(employeeModel);
        }
    }
}
