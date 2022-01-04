using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class LoginRequest
    {
        public LoginRequest(string email, string pass)
        {
            username = email;
            password = pass;
        }
        public string username { get; set; }
        public string password { get; set; }
    }
}
