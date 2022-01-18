using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class WeeklyReportDTO
    {
       public List<Daily> weeklyCost { get; set; }
       public List<Daily> weeklyPaid { get; set; }

    }

    public class Daily 
    {
        public int? id { get; set; }
        public DateTime? date { get; set; }
        public string status { get; set; }
        public int? paid { get; set; }
        public int? cost { get; set; }
    }

}
