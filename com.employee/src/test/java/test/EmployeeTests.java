package test;

import java.util.Map;

import org.testng.Assert;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import com.github.javafaker.Faker;

import endpoint.EmployeeEndPoints;
import io.restassured.response.Response;
import payload.Employee;

public class EmployeeTests {
	
	Faker faker;
	Employee employeePayload;
	
	@BeforeClass
	public void setup() {
		faker = new Faker();
		employeePayload = new Employee();
		
		employeePayload.setEmployeeName(faker.name().firstName());
		employeePayload.setAddress(faker.address().cityName());
		employeePayload.setDepartment(faker.company().profession());
		
	}
	
	@Test(priority=1)
	public void testPostEmployee() {
		Response response = EmployeeEndPoints.createEmployee(employeePayload);
		response.then().log().all();	
		
	}
	
	@Test(priority=2)
	public void testGetAllEmployee() {
		Response response = EmployeeEndPoints.readAllEmployee();
		response.then().log().all();
		
		Assert.assertEquals(response.getStatusCode(), 200);
		
	}
	
	@Test(priority=3)
	public void testGetEmployeeById() {
		Response createResponse = EmployeeEndPoints.createEmployee(employeePayload);
		createResponse.then().log().all();
		Map<String, Object> jsonAsMap = createResponse.getBody().as(Map.class);
		
		Response getEmployeeByIdResponse = 
				EmployeeEndPoints.readEmployeeById((Integer)jsonAsMap.get("employeeID"));
		
		getEmployeeByIdResponse.then().log().all();
		
		Assert.assertEquals(getEmployeeByIdResponse.getStatusCode(), 200);
	}
	
	@Test(priority = 4)
	public void testUpdateEmployee() {
		Response createResponse = EmployeeEndPoints.createEmployee(employeePayload);
		createResponse.then().log().all();
		Map<String, Object> jsonAsMap = createResponse.getBody().as(Map.class);
		
		employeePayload.setEmployeeName(faker.name().firstName());
		employeePayload.setAddress(faker.address().cityName());
		employeePayload.setDepartment(faker.company().profession());
		
		Response updateEmployeeResponse = 
				EmployeeEndPoints.updateEmployee((Integer)jsonAsMap.get("employeeID"), 
						employeePayload);
		updateEmployeeResponse.then().log().all();	
		
		Assert.assertEquals(updateEmployeeResponse.getStatusCode(), 200);
	}
	
	@Test(priority = 5)
    public void testDeleteEmployee() {
		Response createResponse = EmployeeEndPoints.createEmployee(employeePayload);
		createResponse.then().log().all();
		Map<String, Object> jsonAsMap = createResponse.getBody().as(Map.class);
		
		Response deleteResponse = 
				EmployeeEndPoints.deleteEmployee((Integer)jsonAsMap.get("employeeID"));
		deleteResponse.then().log().all();
		
		Assert.assertEquals(deleteResponse.getStatusCode(), 200);
		
		
	}

}
