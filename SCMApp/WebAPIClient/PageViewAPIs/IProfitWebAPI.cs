

using SCMApp.WebAPIClient.Request_Response;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IProfitWebAPI
    {
        GetAllProfitResponseDTO GetProfitByCriteria(string token);
    }
}
