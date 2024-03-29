using Bogus;
using EmployeeRestApiAutomation.Endpoints;
using EmployeeRestApiAutomation.Payload;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


namespace EmployeeRestApiAutomation.Test
{
    public class EmployeeTests
    {
        Faker faker;
        Employee employee;
        EmployeeEndPoint employeeEndPoint = new EmployeeEndPoint(Routes.base_url);

        [SetUp]
        public void SetUp()
        {
            faker = new Faker();
            employee = new Employee();
            employee.EmployeeName = faker.Name.FirstName();
            employee.address = faker.Address.StreetAddress();
            employee.Department = faker.Company.CompanyName();
        }

        [Test, Order(1)]
        public void GetEmployee()
        {
            var getEmployeeResponse = employeeEndPoint.ReadEmployee();
            Assert.AreEqual(200, (int)getEmployeeResponse.StatusCode);
        }

        [Test, Order(2)]
        public void GetEmployeeById()
        {
            var getEmployeeById = employeeEndPoint.ReadEmployeeById(1);
            Assert.AreEqual(200, (int)getEmployeeById.StatusCode);
        }

        [Test, Order(3)]
        public void CreateEmployee()
        {
            var createEmployeeResponse = employeeEndPoint.CreateEmployee(employee);
            Assert.AreEqual(200, (int)createEmployeeResponse.StatusCode);
        }

        [Test, Order(4)]
        public void UpdateEmployee()
        {
            //we will create a employee record first in order to update it
            var createEmployeeResponse = employeeEndPoint.CreateEmployee(employee);

            // we will store create employee response content in the JObject
            JObject responseObject = JObject.Parse(createEmployeeResponse.Content);

            // we will assign values to employee payload using faker/bogus
            employee.EmployeeName = faker.Name.FirstName();
            employee.address = faker.Address.StreetAddress();
            employee.Department = faker.Company.CompanyName();

            //update the created record above 
            var updateEmployeeResponse = employeeEndPoint.UpdateEmployee((int)responseObject["employeeID"], employee);
            Assert.AreEqual(200, (int)updateEmployeeResponse.StatusCode);
        }

        [Test, Order(5)]

        public void DeleteEmployee()
        {
            // we will create a employee record first to delete it
            var createEmployeeResponse = employeeEndPoint.CreateEmployee(employee);

            // we will store create employee response content in the JObject
            JObject responseObject = JObject.Parse(createEmployeeResponse.Content);

            //delete the above created records
            var deleteEmployeeResponse = employeeEndPoint.DeleteEmployee((int)responseObject["employeeID"]);
            Assert.AreEqual(200, (int)deleteEmployeeResponse.StatusCode);
        }
    }
}
