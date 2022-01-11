using System; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ImportStockWebAPI : WebApiClientBase, IImportStockWebAPI
    {
        public ImportStockWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public void CreateImportStock()
        {
            throw new NotImplementedException();
        }

        public void DeleteImportStock()
        {
            throw new NotImplementedException();
        }
    }
}
