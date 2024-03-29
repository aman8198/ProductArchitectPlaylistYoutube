package endpoint;

import static io.restassured.RestAssured.given;

import io.restassured.http.ContentType;
import io.restassured.response.Response;
import payload.Employee;

public class EmployeeEndPoints {
	 
	public static Response createEmployee(Employee payload) {
		Response response = 
				given ()
				 .contentType(ContentType.JSON)
				 .accept(ContentType.JSON)
				 .body(payload)
				.when()
				.post(Routes.post_Employee_url);
		
		return response;
		
	}
	
	public static Response readEmployeeById(int Id) {
		Response response = 
				given()
				.pathParam("Id", Id)
				.when()
				.get(Routes.get_Employee_By_Id_url);
		
		return response;
	}
	
	public static Response readAllEmployee() {
		Response response = 
				given()
				.get(Routes.get_all_Employee_url);
		
		return response;
	}
	
	public static Response updateEmployee(int Id, Employee payload) {
		Response response =
				given()
				 .contentType(ContentType.JSON)
				 .accept(ContentType.JSON)
				 .pathParam("Id", Id)
		         .body(payload)
		        .when()
		         .put(Routes.update_Employee_url);
		
		return response;
	}
	
	public static Response deleteEmployee(int Id) {
		Response response = 
				given()
				 .pathParam("Id", Id)
				.when()
				 .delete(Routes.delete_Employee_url);
		
		return response;
		
	}

}
