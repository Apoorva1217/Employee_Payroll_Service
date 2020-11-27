using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public DateTime Start_Date { get; set; }
        public char Gender { get; set; }
        public string Phone_Number { get; set; }
        public string Employee_Address { get; set; }
        public string Department { get; set; }
        public double Basic_Pay { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
        public string SalaryMonth { get; set; }
        public int SalaryId { get; set; }
        public int DeptId { get;  set; }
        public string  DeptName { get;  set; }
        public string DeptLocation { get;  set; }

        public EmployeeModel()
        {
        }

        public EmployeeModel(int EmpId,string EmpName, double Salary, DateTime Start_Date, char Gender, string Phone_Number, 
            string Employee_Address, string Department, double Basic_Pay, double Deductions, double Taxable_Pay, double Income_Tax,
            double Net_Pay, string SalaryMonth, int SalaryId, int DeptId, string DeptName, string DeptLocation)
        {
            this.EmpId = EmpId;
            this.EmpName = EmpName;
            this.Salary = Salary;
            this.Start_Date = Start_Date;
            this.Gender = Gender;
            this.Phone_Number = Phone_Number;
            this.Employee_Address = Employee_Address;
            this.Department = Department;
            this.Basic_Pay = Basic_Pay;
            this.Deductions = Deductions;
            this.Taxable_Pay = Taxable_Pay;
            this.Income_Tax = Income_Tax;
            this.Net_Pay = Net_Pay;
            this.SalaryMonth = SalaryMonth;
            this.SalaryId = SalaryId;
            this.DeptId = DeptId;
            this.DeptName = DeptName;
            this.DeptLocation = DeptLocation;
        }
    }
}
