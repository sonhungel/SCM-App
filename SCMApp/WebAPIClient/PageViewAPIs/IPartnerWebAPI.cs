using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IPartnerWebAPI
    {
        void AddSupplier();
        void GetAllSupplier();
        void UpdateSupplier();
        void DeleteSupplier();
    }
}
