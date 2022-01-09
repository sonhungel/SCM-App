using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IPartnerWebAPI
    {
        void AddSupplier();
        IList<Partner> GetAllSupplier(string token);
        void UpdateSupplier();
        void DeleteSupplier();
    }
}
