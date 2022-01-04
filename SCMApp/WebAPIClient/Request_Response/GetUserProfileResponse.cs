using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetUserProfileResponse
    {
        public string message { get; set; }
        public string status { get; set; }
        public UserProfile data { get; set; }
    }
}
