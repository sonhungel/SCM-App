using SCMApp.Models;
using SCMApp.Models.DTOObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.MainView
{
    public interface ILoginWebAPI
    {
        UserProfile GetUserProfile(LoginInfo infor);
    }
}
