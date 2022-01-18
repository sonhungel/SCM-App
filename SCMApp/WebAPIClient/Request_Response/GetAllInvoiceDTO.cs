using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetAllInvoiceDTO
    {
        public bool hasNext { get; set; }
        public bool hasPrevious { get; set; }
        public IList<Order> data { get; set; }
    }
}
