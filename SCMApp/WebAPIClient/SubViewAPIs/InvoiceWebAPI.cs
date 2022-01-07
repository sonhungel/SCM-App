using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class InvoiceWebAPI : WebApiClientBase, IInvoiceWebAPI
    {
        public InvoiceWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void CreateInvoice()
        {
            throw new NotImplementedException();
        }

        public void DeleteInvoice()
        {
            throw new NotImplementedException();
        }
    }
}
