using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class MonthlyReportDTO
    {
        public List<Item> itemsWarning { get; set; }
        public List<Item> itemsOutOfStock { get; set; }
        public long cost { get; set; }
        public long paid { get; set; }
    }
}
