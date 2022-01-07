using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IInventoryWebAPI
    {
        void CreateInventoryTicket();
        void DeleteInventoryTicket();
    }
}
