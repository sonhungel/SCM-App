using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface ICustomerWebAPI
    {
        Customer AddCustomer(string token);
        IList<Customer> GetAllCustomer(string token);
        Customer UpdateCustomer(string token);
        bool DeleteCustomer(string token);
    }
}
