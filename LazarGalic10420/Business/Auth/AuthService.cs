using LazarGalic10420.Business.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Auth
{
    public class AuthService : BaseService
    {
        private class TokenReponse
        {
            public string token { get; set; }
        }

        public AuthService() { }

        public User Auth(string email, string password)
        {
            RestRequest request = new RestRequest("token");

            request.AddJsonBody(new { email = email, password = password });

            //106.15.0
            var response = Client.Post<TokenReponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var claims = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.token);

            var mail = claims.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            var userId = claims.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var exp = claims.Claims.FirstOrDefault(x => x.Type == "exp").Value;

            DateTime expirationDate = double.Parse(exp).ToDateTime();

            return new User
            {
                Email = email,
                Id = Int32.Parse(userId),
                Token = response.Data.token,
                LoginExpiration = expirationDate
            };
        }
    }
}
