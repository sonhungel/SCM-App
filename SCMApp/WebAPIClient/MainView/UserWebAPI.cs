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
        public override string RoutePrefix => RouteConstants.LoginApi;

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public IList<UserProfile> GetAllUserProfile(string token)
        {
            return Task.Run(() => Get<GetAllResponse<UserProfile>>(RouteConstants.GetAllUser, token)).Result.data;
        }

        public LoginResponse GetToken(LoginRequest infor)
        {
            return Task.Run(() => Post<LoginResponse>(RouteConstants.LoginApiGetToken, infor, string.Empty)).Result;
        }

        public UserProfile GetUserProfileBaseOnToken(string token)
        {
            return Task.Run(() => Get<GetUserProfileResponse>(RouteConstants.GetUserProfileBaseOnToken, token)).Result.data;
        }

        public void UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
