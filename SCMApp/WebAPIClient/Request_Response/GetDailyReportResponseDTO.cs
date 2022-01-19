using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class GetReportResponseDTO
    {
        public DailyReportDTO daily { get; set; }
        public WeeklyReportDTO weekly { get; set; }
        public MonthlyReportDTO monthly { get; set; }
    }
}
