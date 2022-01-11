using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;

namespace SCMApp.WebAPIClient.MainView
{
    public interface IUserWebAPI
    {
        LoginResponse GetToken(LoginRequest infor);
        UserProfile GetUserProfileBaseOnToken(string username, string token);
        IList<UserProfile> GetAllUserProfile(string token);
        bool CreateUser(CreateUserDTO createUserDTO, string token);
        bool UpdateUser();
        bool DeleteUser(string token);
    }
}
