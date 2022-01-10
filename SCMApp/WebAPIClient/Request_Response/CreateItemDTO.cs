using SCMApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateItemDTO
    {
        public int itemNumber { get; set; }
        public string name { get; set; }
        public string state => "ONS";
        public ItemtypeNumber itemType { get; set; }
        public int cost { get; set; }
        public int salesPrice { get; set; }
        public int quantity { get; set; }
        public int minimumQuantity { get; set; }
        public SupplierNumber supplier { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
    }
}
