using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface ICustomerWebAPI
    {
        void AddCustomer();
        void GetAllCustomer();
        void UpdateCustomer();
        void DeleteCustomer();
    }
}
