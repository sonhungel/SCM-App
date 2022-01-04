using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class LoginResponse
    {
        public bool success { get; set; }
        public string token { get; set; }
    }
}
