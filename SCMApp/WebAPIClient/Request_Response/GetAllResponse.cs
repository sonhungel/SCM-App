using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetAllResponse<T>
    {
        public string message { get; set; }
        public string status { get; set; }
        public IList<T> data { get; set; }
    }
}
