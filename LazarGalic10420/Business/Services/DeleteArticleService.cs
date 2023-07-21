using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public class DeleteArticleService : BaseService
    {
        public bool DeleteArticle(int idToDelete)
        {

            string endpoint = "/user/article";
            RestRequest request = new RestRequest(endpoint);

            string token = Preferences.Get("jwt", null);
            string authorization = "Bearer " + token;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization" , authorization);
            object bodyDto = new { idArticle = idToDelete };
            request.AddJsonBody(bodyDto);

            var response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;

            return false;
        }


    }
}
