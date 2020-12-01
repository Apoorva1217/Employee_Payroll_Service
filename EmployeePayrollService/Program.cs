using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            employeeRepo.GetAllEmployee();
            ///Update Employee Salary
            employeeModel.SalaryId = 1;
            employeeModel.SalaryMonth = "Jan";
            employeeModel.Salary = 500000.00;
            employeeModel.EmpId = 2;
            employeeRepo.UpdateEmployeeSalary(updateModel);
            ///Get All Employee in a particular data range
            employeeRepo.GetAllEmployeeInADataRange();
            ///Get data by Gender
            employeeRepo.GetDataByGroupByGender();
            
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
            employeeRepo.AddEmployee(employeeModel);
            ///Remove particular employee entry using EmpId
            employeeRepo.RemoveEmployee();
            ///Get Employee Details present in Employee table
            employeeRepo.GetAllEmployeeDetails();
            ///Get Department details from Department table
            employeeRepo.GetAllDepartment();
            ///Get Salary of Employee from Salary table
            employeeRepo.GetEmployeeSalary();
            ///Get Data by Gender using joins
            employeeRepo.GetDataByGroupByGenderER();

            Console.WriteLine("Employee Payroll using Threads");
            ///retrieve url
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

            #region ParallelTasks
            Parallel.Invoke
            ( () =>
            {
                Console.WriteLine("Begin First Task...");
                GetLongestWord(words);
            },
            () =>
                {
                    Console.WriteLine("Begin Second Task...");
                    GetMostCommonWords(words);
                }, //close second action
            () =>
                {
                    Console.WriteLine("Begin Third Task...");
                    GetCountForWord(words,"Sleep");
                } //close third action
            ); //close parallel.invoke

            #endregion
        }

        private static void GetCountForWord(string[] words,string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine($@"Task 3 --The word ""{term}"" occurs {findWord.Count()} times");
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequnecyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            var commonWords = frequnecyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 --The most common words are:");
            foreach(var v in commonWords)
            {
                sb.AppendLine(" " + v);
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();
            Console.WriteLine($"Task 1 --The longest word is (longestWord)");
            return longestWord;
        }

        static string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retrieveving from {url}");
            ///download web page 
            string blog = new WebClient().DownloadString(url);
            ///separate string into an array of words,removing some common punctuations
            return blog.Split(
                new char[] { ' ', ',', '.', ':', ';', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
