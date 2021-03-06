using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response; 
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IPartnerWebAPI
    {
        bool CreateSupplier(CreateSupplierDTO createSupplierDTO, string token);
        IList<Partner> GetAllSupplier(string token);
        bool UpdateSupplier(UpdateSupplierDTO updateSupplierDTO, string token);
        bool DeleteSupplier(string supplier, string token);
    }
}
