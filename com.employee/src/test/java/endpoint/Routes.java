package endpoint;

public class Routes {
	public static String base_url = "http://localhost:5273/api/";
	
	//Employee Model
	public static String get_all_Employee_url = base_url + "Employee";
	public static String post_Employee_url = base_url + "Employee";
	public static String get_Employee_By_Id_url = base_url + "Employee/{Id}";
	public static String update_Employee_url = base_url + "Employee/{Id}";
	public static String delete_Employee_url = base_url + "Employee/{Id}";

}
