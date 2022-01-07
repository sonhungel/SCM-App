using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class InventoryWebAPI : WebApiClientBase, IInventoryWebAPI
    {
        public InventoryWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void CreateInventoryTicket()
        {
            throw new NotImplementedException();
        }

        public void DeleteInventoryTicket()
        {
            throw new NotImplementedException();
        }
    }
}
