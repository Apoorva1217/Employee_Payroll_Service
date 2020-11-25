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
    }
}
