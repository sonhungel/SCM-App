using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class CustomerWebAPI : WebApiClientBase, ICustomerWebAPI
    {
        public CustomerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.CustomerApi;

        public Customer AddCustomer(string token)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string token)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAllCustomer(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Customer>>(RouteConstants.GetAllCustomer, token)).Result.data;
        }

        public Customer UpdateCustomer(string token)
        {
            throw new NotImplementedException();
        }
    }
}
