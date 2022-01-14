using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class UpdateItemDTO
    {
        public int itemNumber { get; set; }
        public string name { get; set; }
        public int version { get; set; }
        public int cost { get; set; }
        public int salesPrice { get; set; }
        public int minimumQuantity { get; set; }
    }
}
