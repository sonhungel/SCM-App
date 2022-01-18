using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class DailyReportDTO
    {
        public int? id { get; set; }
        public DateTime? date { get; set; }
        public int user { get; set; }
        public string status { get; set; }
        public int? paid { get; set; }
        public int? cost { get; set; }
    }
}
