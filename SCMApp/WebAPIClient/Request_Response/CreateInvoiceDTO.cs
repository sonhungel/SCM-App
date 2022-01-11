using System;
using System.Collections.Generic;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateInvoiceDTO
    {
        public CustomerNumber customer { get; set; }
        public IList<CreateInvoiceDetailDTO> invoiceDetailDtoList { get; set; }
    }
}
