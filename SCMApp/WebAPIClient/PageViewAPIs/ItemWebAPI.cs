using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    internal class ItemWebAPI : WebApiClientBase, IItemWebAPI
    {
        public ItemWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.ItemApi;

        public bool CreateItem(CreateItemDTO createItemDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Item>>(RouteConstants.CreateNewItem, createItemDTO, token)).Result.status == "OK";
        }

        public string DeleteItem()
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetAllItem(string token)
        {
            return Task.Run(() => Get<IList<Item>>(string.Format(RouteConstants.SearchItem,string.Empty), token)).Result;
        }

        public Item GetItemByItemNumber(string numberRequest, string token)
        {
            return Task.Run(() => Get<GetOneResponse<Item>>(string.Format(RouteConstants.GetItemByItemNumber, numberRequest), token)).Result.data;
        }

        public string UpdateItem(string token)
        {
            throw new NotImplementedException();
        }
    }
}
