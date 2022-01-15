using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic; 
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

        public bool DeleteItem(string item, string token)
        {
            return Task.Run(() => Delete<GetOneResponse<Item>>(string.Format(RouteConstants.DeleteItem, item), token)).Result.status == "OK";
        }

        public IList<Item> GetAllItem(string token)
        {
            return Task.Run(() => Get<IList<Item>>(string.Format(RouteConstants.SearchItem,string.Empty), token)).Result;
        }

        public Item GetItemByItemNumber(string numberRequest, string token)
        {
            return Task.Run(() => Get<GetOneResponse<Item>>(string.Format(RouteConstants.GetItemByItemNumber, numberRequest), token)).Result.data;
        }

        public bool UpdateItem(UpdateItemDTO updateItemDTO, string token)
        {
            return Task.Run(() => Put<GetOneResponse<Item>>(RouteConstants.UpdateItem, updateItemDTO, token)).Result.status == "OK";
        }
    }
}
