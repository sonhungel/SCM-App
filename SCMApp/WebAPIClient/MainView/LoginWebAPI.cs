using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Models.DTOObject;
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
        public override string RoutePrefix => RouteConstants.UserApi;

        public UserProfile GetUserProfile(LoginInfo infor)
        {
            return Task.Run(() => Post<UserProfile>(RouteConstants.UserLoginApi, infor)).Result;
        }

    }
}
