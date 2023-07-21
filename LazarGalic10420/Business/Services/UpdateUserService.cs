using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public class UpdateUserService : BaseService
    {
        public bool UpdateUser(UpdateOneUserDto dto)
        {
            string endpoint = "/user";
            RestRequest request = new RestRequest(endpoint);

            string token = Preferences.Get("jwt", null);
            string authorization = "Bearer " + token;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", authorization);
            request.AddJsonBody(dto);

            var response = Client.Put(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            return false;
        }
    }
}
