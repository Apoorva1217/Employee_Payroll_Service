using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 1,
                SalaryMonth = "Jan",
                Salary = 500000,
                EmpId = 1
            };
            int EmpSalary = employeeRepo.UpdateEmployeeSalary(updateModel);
            Assert.AreEqual(updateModel.Salary, EmpSalary);
        }
    }
}
