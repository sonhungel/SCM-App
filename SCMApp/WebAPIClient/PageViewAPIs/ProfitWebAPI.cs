using SCMApp.Constants;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ProfitWebAPI : WebApiClientBase, IProfitWebAPI
    {
        public ProfitWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override string RoutePrefix => RouteConstants.ProfitApi;

        public GetAllProfitResponseDTO GetProfitByCriteria(string token)
        {
            return Task.Run(() => Get<GetOneResponse<GetAllProfitResponseDTO>>(RouteConstants.AllReport, token)).Result.data;
        }
    }
}
