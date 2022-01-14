using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateImportStockDTO
    {
        public SupplierId supplier { get; set; }
        public ItemId item { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
        public string remark { get; set; }
    }

    public class ItemId
    {
        public int id { get; set; }
    }

    public class SupplierId
    {
        public int id { get; set; }
    }
}
