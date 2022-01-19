using SCMApp.Constants;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ProfitWebAPI : WebApiClientBase, IProfitWebAPI
    {
        public ProfitWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.ProfitApi;

        public GetReportResponseDTO GetDailyReport(string token)
        {
            return Task.Run(() => Get<GetOneResponse<GetReportResponseDTO>>(RouteConstants.AllReport, token)).Result.data;
        }

        public IList<IList<IList<MoreDetailDTO>>> GetMonthlyReport(string token)
        {
            return Task.Run(() => Get<GetAllResponse<IList<IList<MoreDetailDTO>>>>(RouteConstants.MonthlyReport, token)).Result.data;
        }
    }
}
