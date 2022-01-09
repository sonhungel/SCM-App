using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ItemTypeWebAPI : WebApiClientBase, IItemTypeWebAPI
    {
        public ItemTypeWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.ItemTypeApi;


        public IList<ItemType> GetAllItemType(string token)
        {
            return Task.Run(() => Get<GetAllResponse<ItemType>>(RouteConstants.GetAllItemType, token)).Result.data;
        }
    }
}
