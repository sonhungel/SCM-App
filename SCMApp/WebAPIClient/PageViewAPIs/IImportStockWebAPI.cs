using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IImportStockWebAPI
    {
        bool CreateImportStock(CreateImportStockDTO createImportStockDTO, string token);
        IList<ImportStock> GetImportStocks(string token);
    }
}
