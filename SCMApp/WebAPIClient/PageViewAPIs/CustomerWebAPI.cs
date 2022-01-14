using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class CustomerWebAPI : WebApiClientBase, ICustomerWebAPI
    {
        public CustomerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.CustomerApi;

        public bool CreateCustomer(CreateCustomerDTO createCustomerDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Customer>>(RouteConstants.CreateCustomer, 
                createCustomerDTO, token)).Result.status == "OK";
        }

        public bool DeleteCustomer(string token)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAllCustomer(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Customer>>(RouteConstants.GetAllCustomer, token)).Result.data;
        }

        public bool UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, string token)
        {
            throw new NotImplementedException();
        }
    }
}
