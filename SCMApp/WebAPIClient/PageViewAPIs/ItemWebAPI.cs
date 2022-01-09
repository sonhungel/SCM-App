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

        public void CreateItem()
        {
            throw new NotImplementedException();
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetAllItem(string token)
        {
            return Task.Run(() => Get<IList<Item>>(string.Format(RouteConstants.SearchItem,string.Empty), token)).Result;
        }

        public Item GetItemByItemNumber(string numberRequest, string token)
        {
            return Task.Run(() => Get<GetItemByNumberReSponse>(string.Format(RouteConstants.GetItemByItemNumber, numberRequest), token)).Result.data;
        }

        public void UpdateItem()
        {
            throw new NotImplementedException();
        }
    }
}
