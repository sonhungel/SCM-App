using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class PartnerWebAPI : WebApiClientBase, IPartnerWebAPI
    {
        public PartnerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void AddSupplier()
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier()
        {
            throw new NotImplementedException();
        }

        public void GetAllSupplier()
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
