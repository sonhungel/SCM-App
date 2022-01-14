using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public class ImportStockWebAPI : WebApiClientBase, IImportStockWebAPI
    {
        public ImportStockWebAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public bool CreateImportStock(CreateImportStockDTO createImportStockDTO, string token)
        {
            return Task.Run(() => Post<GetOneResponse<Item>>(RouteConstants.ImportStockApi, createImportStockDTO, token)).Result.status == "OK";
        }

        public IList<ImportStock> GetImportStocks(string token)
        {
            return Task.Run(() => Get<GetAllResponse<ImportStock>>(RouteConstants.ImportStockApi, token)).Result.data;
        }
    }
}
