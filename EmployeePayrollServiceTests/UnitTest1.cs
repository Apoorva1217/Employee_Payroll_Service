using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace EmployeePayrollServiceTests
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        /// <summary>
        /// Initialize Rest client with localhost:4000
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        /// <summary>
        /// Ability to Retrieve all Employees in EmployeePayroll JSON Server
        /// </summary>
        [TestMethod]
        public void OnCallingList_ReturnEmployeeList()
        {
            IRestResponse restResponse = GetEmployeeList();
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(restResponse.Content);
            Assert.AreEqual(5, employees.Count);

            foreach(Employee employee in employees)
            {
                Console.WriteLine("EmpId:" + employee.EmpId + "\nEmpName:" + employee.EmpName + "\nSalary:" + employee.Salary);
            }
        }

        /// <summary>
        /// Interface to get List of Employees
        /// </summary>
        /// <returns></returns>
        private IRestResponse GetEmployeeList()
        {
            RestRequest restRequest = new RestRequest("/employeePayroll", Method.GET);
            IRestResponse response = client.Execute(restRequest);
            return response;
        }

        /// <summary>
        /// Given salary details are able to update Salary
        /// </summary>
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 1,
                SalaryMonth = "Jan",
                Salary = 500000,
                EmpId = 2
            };
            int EmpSalary = employeeRepo.UpdateEmployeeSalary(updateModel);
            Assert.AreEqual(updateModel.Salary, EmpSalary);
        }

        /// <summary>
        /// Ability to add multiple employee with and without thread
        /// </summary>
        [TestMethod]
        public void GivenEmployee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            
            employeeModelList.Add(new EmployeeModel(EmpId: 1, EmpName: "Apoorva", Salary: 500000, Start_Date: Convert.ToDateTime("2020-02-06"), Gender: 'F', Phone_Number: "9876543212",
                Employee_Address: "Pune", Department: "Sales", Basic_Pay: 5432, Deductions: 8765, Taxable_Pay: 6754, Income_Tax: 5432, Net_Pay: 98765,
                SalaryMonth:"July", SalaryId: 1, DeptId: 1, DeptName: "Sales", DeptLocation: "Pune"));
            
            employeeModelList.Add(new EmployeeModel(EmpId: 2, EmpName: "Aarya", Salary: 400000, Start_Date: Convert.ToDateTime("2020-08-02"), Gender: 'F', Phone_Number: "9076543212",
                Employee_Address: "Mumbai", Department: "Marketing", Basic_Pay: 5422, Deductions: 5765, Taxable_Pay: 7754, Income_Tax: 6432, Net_Pay: 88765,
                SalaryMonth: "August", SalaryId: 2, DeptId: 2, DeptName: "Marketing", DeptLocation: "Mumbai"));
            
            employeeModelList.Add(new EmployeeModel(EmpId: 3, EmpName: "Yash", Salary: 600000, Start_Date: Convert.ToDateTime("2019-04-12"), Gender: 'M', Phone_Number: "9976543222",
                Employee_Address: "NaviMumbai", Department: "Development", Basic_Pay: 5444, Deductions: 6765, Taxable_Pay: 7954, Income_Tax: 6452, Net_Pay: 78765,
                SalaryMonth: "June", SalaryId: 3, DeptId: 3, DeptName: "Development", DeptLocation: "NaviMumbai"));

            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime StartDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll(employeeModelList);
            DateTime StopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread:" + (StopDateTime - StartDateTime));

            DateTime StartDateTimeThread = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollWithThread(employeeModelList);
            DateTime StopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread:" + (StopDateTimeThread - StartDateTimeThread));
        }

        /// <summary>
        /// Ability to add multiple employee with thread with synchronization
        /// </summary>
        [TestMethod]
        public void GivenEmployeeAddedIntoList_WithThreadWithSynchronization()
        {
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollWithThreadWithSynchronization(employeeModelList);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration with thread:" + (stopDateTime - startDateTime));
        }


    }
}
