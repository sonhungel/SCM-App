using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.MainView
{
    public interface IUserWebAPI
    {
        UserProfile GetUserProfile(string token);
        void GetAllUserProfile();
        void AddUser();
        void UpdateUser();
        void DeleteUser();
    }
}
