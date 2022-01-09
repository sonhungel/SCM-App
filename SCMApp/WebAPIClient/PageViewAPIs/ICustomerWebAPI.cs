using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface ICustomerWebAPI
    {
        void AddCustomer();
        IList<Customer> GetAllCustomer(string token);
        void UpdateCustomer();
        void DeleteCustomer();
    }
}
