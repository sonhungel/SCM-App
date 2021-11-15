using System.Net.Http;

namespace SCMApp.WebAPIClient
{
    public interface IHttpClientFactory
    {
        HttpClient GetClient();
    }
}
