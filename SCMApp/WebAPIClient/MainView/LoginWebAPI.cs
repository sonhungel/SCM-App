using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.MainView
{
    public class LoginWebAPI : WebApiClientBase, ILoginWebAPI
    {
        public LoginWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public override string RoutePrefix => RouteConstants.LoginApi;

        public LoginResponse GetToken(LoginRequest infor)
        {
            return Task.Run(() => Post<LoginResponse>(RouteConstants.LoginApiGetToken, infor, string.Empty)).Result;
        }

    }
}
