using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetItemByNumberRequest
    {
        public GetItemByNumberRequest(int number )
        {
            itemNumber = number;
        }
        public int itemNumber { get; set; }
    }
}
