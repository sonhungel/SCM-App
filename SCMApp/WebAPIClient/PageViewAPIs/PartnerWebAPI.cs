using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class PartnerWebAPI : WebApiClientBase, IPartnerWebAPI
    {
        public PartnerWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.PartnerApi;

        public void AddSupplier()
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier()
        {
            throw new NotImplementedException();
        }

        public IList<Partner> GetAllSupplier(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Partner>>(RouteConstants.GetAllPartner, token)).Result.data;
        }

        public void UpdateSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
