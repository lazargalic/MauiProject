using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public abstract class BaseService
    {
        protected virtual string BaseUrl => "https://localhost:7141/api";
        protected RestClient Client { get; }

        public BaseService()
        {
            Client = new RestClient(BaseUrl);
        }
    }
}
