﻿using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.MainView
{
    public interface ILoginWebAPI
    {
        LoginResponse GetToken(LoginRequest infor);
    }
}
