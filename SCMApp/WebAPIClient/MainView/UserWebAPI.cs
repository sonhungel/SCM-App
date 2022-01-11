using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.MainView
{
    public class UserWebAPI : WebApiClientBase, IUserWebAPI
    {
        public UserWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public override string RoutePrefix => RouteConstants.UserApi;

        public bool CreateUser(CreateUserDTO createUserDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<UserProfile>>(RouteConstants.CreateUser, createUserDTO, string.Empty)).Result.status == "CREATED";
        }

        public bool DeleteUser(string token)
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

        public UserProfile GetUserProfileBaseOnToken(string username, string token)
        {
            return Task.Run(() => Get<GetOneResponse<UserProfile>>(username, token)).Result.data;
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
