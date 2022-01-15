using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class PartnerWebAPI : WebApiClientBase, IPartnerWebAPI
    {
        public PartnerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.PartnerApi;

        public bool CreateSupplier(CreateSupplierDTO createSupplierDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Partner>>(RouteConstants.CreateParter,
                createSupplierDTO, token)).Result.status == "OK";
        }

        public bool DeleteSupplier(string supplier, string token)
        {
            return Task.Run(() => Delete<GetOneResponse<Partner>>(string.Format(RouteConstants.DeleteSupplier, supplier), token)).Result.status == "OK";
        }

        public IList<Partner> GetAllSupplier(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Partner>>(RouteConstants.GetAllPartner, token)).Result.data;
        }

        public bool UpdateSupplier(UpdateSupplierDTO updateSupplierDTO, string token)
        {
            return Task.Run(() => Put<GetOneResponse<Partner>>(RouteConstants.UpdatePartner,
               updateSupplierDTO, token)).Result.status == "OK";
        }
    }
}
