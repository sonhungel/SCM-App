using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.MainView
{
    public interface IUserWebAPI
    {
        LoginResponse GetToken(LoginRequest infor);
        UserProfile GetUserProfileBaseOnToken(string token);
        IList<UserProfile> GetAllUserProfile(string token);
        void AddUser();
        void UpdateUser();
        void DeleteUser();
    }
}
