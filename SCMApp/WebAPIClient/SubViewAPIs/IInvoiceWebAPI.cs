using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IInvoiceWebAPI
    {
        bool CreateInvoice(CreateInvoiceDTO createInvoiceDTO, string token);
        void DeleteInvoice();
        GetAllInvoiceDTO GetAllInvoice(int pageNumber, string token);
    }
}
