using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class InvoiceWebAPI : WebApiClientBase, IInvoiceWebAPI
    {
        public InvoiceWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.InvoiceApi;

        public void CreateInvoice()
        {
            throw new NotImplementedException();
        }

        public void DeleteInvoice()
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAllInvoice(string token)
        {
            return Task.Run(() => Get<GetAllResponse<Order>>(RouteConstants.GetAllInvoice, token)).Result.data;
        }
    }
}
