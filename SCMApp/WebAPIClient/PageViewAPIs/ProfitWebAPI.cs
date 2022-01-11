using System;
namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ProfitWebAPI : WebApiClientBase, IProfitWebAPI
    {
        public ProfitWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void GetProfitByCriteria()
        {
            throw new NotImplementedException();
        }
    }
}
