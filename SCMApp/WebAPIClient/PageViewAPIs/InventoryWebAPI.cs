using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class InventoryWebAPI : WebApiClientBase, IInventoryWebAPI
    {
        public InventoryWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.InventoryApi;

        public bool CreateInventoryTicket(CreateInventoryDTO requestObj, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Inventory>>(RouteConstants.CreateInventoryTicket, requestObj, token)).Result.status =="OK";
        }

        public void DeleteInventoryTicket(string token)
        {
            throw new NotImplementedException();
        }

        public IList<Inventory> GetAllInventoryTicket(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Inventory>>(RouteConstants.GetAllInventoryTicket, token)).Result.data;
        }

    }
}
