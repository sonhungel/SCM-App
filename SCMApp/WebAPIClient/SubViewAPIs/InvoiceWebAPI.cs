using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class InvoiceWebAPI : WebApiClientBase, IInvoiceWebAPI
    {
        public InvoiceWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.InvoiceApi;

        public bool CreateInvoice(CreateInvoiceDTO createInvoiceDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Order>>(RouteConstants.CreateInvoice, createInvoiceDTO, token)).Result.status == "OK";
        }

        public void DeleteInvoice()
        {
            throw new NotImplementedException();
        }

        public GetAllInvoiceDTO GetAllInvoice(int pageNumber,string token)
        {
            return Task.Run(() => Get<GetOneResponse<GetAllInvoiceDTO>>(string.Format(RouteConstants.GetAllInvoice, pageNumber), token)).Result.data;
        }
    }
}
