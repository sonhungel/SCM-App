using SCMApp.Constants;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void GetAllItem()
        {
            throw new NotImplementedException();
        }

        public void GetItemByCriteria(string criteria)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem()
        {
            throw new NotImplementedException();
        }
    }
}
