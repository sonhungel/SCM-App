using SCMApp.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ItemTypeWebAPI : WebApiClientBase, IItemTypeWebAPI
    {
        public ItemTypeWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.ItemTypeApi;

        public void GetAllItemType()
        {
            throw new NotImplementedException();
        }
    }
}
