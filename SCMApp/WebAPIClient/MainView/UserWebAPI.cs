using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.MainView
{
    public class UserWebAPI : WebApiClientBase, IUserWebAPI
    {
        public UserWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
           
        }

        public override string RoutePrefix => RouteConstants.UserRoleApi;

        public UserProfile GetUserProfile(string token)
        {
            var response = Task.Run(() => Get<GetUserProfileResponse>(RouteConstants.GetUserProfile, token)).Result;
            return response.data;
        }
    }
}
