using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class SalaryUpdateModel
    {
        public int SalaryId { get; set; }
        public string SalaryMonth { get; set; }
        public int Salary { get; set; }
        public int EmpId { get; set; }
    }
}
