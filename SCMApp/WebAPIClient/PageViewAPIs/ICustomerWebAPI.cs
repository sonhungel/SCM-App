using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response; 
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface ICustomerWebAPI
    {
        bool CreateCustomer(CreateCustomerDTO createCustomerDTO,string token);
        IList<Customer> GetAllCustomer(string token);
        bool UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, string token);
        bool DeleteCustomer(string customer, string token);
    }
}
