using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IInventoryWebAPI
    {
        Inventory CreateInventoryTicket(CreateInventoryDTO requestObj, string token);
        IList<Inventory> GetAllInventoryTicket(string token);
        void DeleteInventoryTicket(string token);
    }
}
