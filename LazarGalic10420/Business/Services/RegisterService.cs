using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public class RegisterService : BaseService
    {
        public bool RegisterUser (RegisterUserDto dto)
        {
            string endpoint = "/registration";
            var request = new RestRequest(endpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody( dto );  // 

            var response = Client.Post(request);

            var statusCode = response.StatusCode;
            if (statusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }

          //  var objj = JsonConvert.DeserializeObject<ServerValidatorError>(response.Content);
         //   var objjResponse = objj.Errors.FirstOrDefault();


            return false;

        }
    }
}

/*
    public class ServerValidatorError
    {
        public IEnumerable<ServerValidatorErrors> Errors { get; set; } = new List<ServerValidatorErrors>();
    }
    public class ServerValidatorErrors
    {
        public string Property { get; set; }
        public string Error { get; set; }
    }

*/