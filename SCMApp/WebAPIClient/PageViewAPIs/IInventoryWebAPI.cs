using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response; 
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IInventoryWebAPI
    {
        bool CreateInventoryTicket(CreateInventoryDTO requestObj, string token);
        IList<Inventory> GetAllInventoryTicket(string token);
        void DeleteInventoryTicket(string token);
    }
}
