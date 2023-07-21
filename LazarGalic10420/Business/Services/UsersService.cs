using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public class UsersService : BaseService
    {
        public IEnumerable<AdminSelectRegisteredUsersDto> GetUsers()
        {
            string endpoint = "/admin/registeredUsers";
            var token = Preferences.Get("jwt", null);
            string authorization = "Bearer " + token;

            RestRequest request = new RestRequest(endpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", authorization);

            var response = Client.Get<List<AdminSelectRegisteredUsersDto>>(request);  //

            var statusCode = response.StatusCode;

            if (statusCode == System.Net.HttpStatusCode.OK) return response.Data;

            return null;
        }
    }
}
