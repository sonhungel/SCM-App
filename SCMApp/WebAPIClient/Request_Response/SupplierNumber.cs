using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class SupplierNumber
    {
        public SupplierNumber(int number)
        {
            supplierNumber = number;
        }
        public int supplierNumber { get; set; }
    }
}
