using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeePayrollOperations
    {
        public List<EmployeeModel> employeePayrollDataList = new List<EmployeeModel>();
        readonly System.Threading.Mutex mutex = new Mutex();

        /// <summary>
        /// Ability to Add Employee To Payroll without Thread
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
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

        /// <summary>
        /// Ability to Add Employee To Payroll with Thread
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayrollWithThread(List<EmployeeModel> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee Being Added: " + employeeData.EmpName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee Added: " + employeeData.EmpName);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDataList.Count);
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

        /// <summary>
        /// Ability to Add Employee To Payroll with Thread with synchronization
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayrollWithThreadWithSynchronization(List<EmployeeModel> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    mutex.WaitOne();
                    Console.WriteLine("Employee Being Added" + employeeData.EmpName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee Added:" + employeeData.EmpName);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    mutex.ReleaseMutex();
                });
                thread.Start();
            });
        }
    }
}
