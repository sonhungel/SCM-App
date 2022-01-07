using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class CustomerWebAPI : WebApiClientBase, ICustomerWebAPI
    {
        public CustomerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void AddCustomer()
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public void GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
