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

        public bool CreateItemtype(ItemType itemType, string token)
        {
            return Task.Run(() => Post<GetOneResponse<ItemType>>(RouteConstants.CreateNewItemtype, itemType, token)).Result.status == "OK";
        }

        public IList<ItemType> GetAllItemType(string token)
        {
            return Task.Run(() => Get<GetAllResponse<ItemType>>(RouteConstants.GetAllItemType, token)).Result.data;
        }

        public ItemType GetItemNewestId(string token)
        {
            return Task.Run(() => Get<GetOneResponse<ItemType>>(RouteConstants.GetNewestIdOfItemtype, token)).Result.data;
        }
    }
}
