using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IProfitWebAPI
    {
        GetReportResponseDTO GetDailyReport(string token);
        IList<IList<IList<MoreDetailDTO>>> GetMonthlyReport(string token);
    }
}
