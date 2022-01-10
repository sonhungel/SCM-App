using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetOneResponse<T>
    {
        public string message { get; set; }
        public string status { get; set; }
        public T data { get; set; }
    }
}
