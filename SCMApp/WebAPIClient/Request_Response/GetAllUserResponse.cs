using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    internal class GetAllUserResponse
    {
        public string message { get; set; }
        public string status { get; set; }
        public IList<UserProfile> data { get; set; }
    }
}
