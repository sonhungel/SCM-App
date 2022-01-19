using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class MonthlyReportResponseDTO
    {
        List<MonthlyPaidDTO> MonthlyPaid { get; set; }
        List<MonthlyCostDTO> MonthlyCost { get; set; }
    }

    public class MonthlyPaidDTO
    {
        List<DetailMonthlyDTO> DetailMonthlyDTOs { get; set; }
    }
    public class MonthlyCostDTO
    {
        List<DetailMonthlyDTO> DetailMonthlyDTOs { get; set; }
    }

    public class DetailMonthlyDTO
    {
        List<MoreDetailDTO> MoreDetailDTOs { get; set; }
    }
    public class MoreDetailDTO
    {
        public DateTime? date { get; set; }
        public long? paid { get; set; }
        public string user { get; set; }
        public long? cost { get; set; }
        public string status { get; set; }
        public int? id { get; set; }
    }

}
