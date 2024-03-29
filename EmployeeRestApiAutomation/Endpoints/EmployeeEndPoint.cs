using EmployeeRestApiAutomation.Payload;
using RestSharp;

namespace EmployeeRestApiAutomation.Endpoints
{
    public class EmployeeEndPoint
    {
        private readonly RestClient _client;
        private readonly string _baseurl;
        public EmployeeEndPoint(string baseurl)
        {
            _baseurl = baseurl;
            _client = new RestClient(_baseurl);
        }

        public RestResponse CreateEmployee(Employee employee)
        {
            var request = new RestRequest(Routes.common_employee_endpoint, Method.Post);
            request.AddJsonBody(employee);
            var response = _client.ExecutePost(request);
            return response;
        }

        public RestResponse ReadEmployee()
        {
            var request = new RestRequest(Routes.common_employee_endpoint, Method.Get);
            var response = _client.ExecuteGet(request);
            return response;
        }

        public RestResponse ReadEmployeeById(int id)
        {
            var request = new RestRequest($"{Routes.common_employee_endpoint}/{id}", Method.Get);
            var response = _client.ExecuteGet(request);
            return response;
        }

        public RestResponse UpdateEmployee(int id, Employee employee)
        {
            var request = new RestRequest($"{Routes.common_employee_endpoint}/{id}", Method.Put);
            request.AddJsonBody(employee);
            var response = _client.ExecutePut(request);
            return response;
        }

        public RestResponse DeleteEmployee(int id)
        {
            var request = new RestRequest($"{Routes.common_employee_endpoint}/{id}", Method.Delete);
            var response = _client.ExecuteDelete(request);
            return response;
        }
    }
}
