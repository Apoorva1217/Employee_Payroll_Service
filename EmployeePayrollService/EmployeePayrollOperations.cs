using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeePayrollOperations
    {
        public List<EmployeeModel> employeePayrollDataList = new List<EmployeeModel>();

        public void AddEmployeeToPayroll(List<EmployeeModel> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee Being Added: " + employeeData.EmpName);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.EmpName);
            });
            Console.WriteLine(this.employeePayrollDataList.ToString());
        }

        public void AddEmployeePayroll(EmployeeModel employeeModel)
        {
            ///Thread.Sleep(100)
            employeePayrollDataList.Add(employeeModel);
        }

        public int EmployeeCount()
        {
            return this.employeePayrollDataList.Count;

        }
    }
}
