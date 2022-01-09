using log4net;
using Newtonsoft.Json;
using SCMApp.Constants;
using SCMApp.Exceptions;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient
{
    public abstract class WebApiClientBase
    {
        public const string ApplicationJson = "application/json";
        public const string RouteFormat = "{0}/{1}";

        protected static readonly ILog ClassTracer = LogManager.GetLogger("SCMApp");

        public static readonly string BaseAddressServices = ConfigurationManager.AppSettings["BaseAddressServices"];
        private readonly IHttpClientFactory _httpClientFactory;

        protected WebApiClientBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public virtual string RoutePrefix => string.Empty;

        protected async Task Get(string url, string token, NameValueCollection queryParams = null)
        {
            string route = GetRoute(url, queryParams);

            ClassTracer.DebugFormat("Request [GET] to url '{0}{1}'", BaseAddressServices, route);
            await PerformWebClientAction(client => client.GetAsync(route), token);
        }

        protected async Task<T> Get<T>(string url, string token, NameValueCollection queryParams = null)
        {
            string route = GetRoute(url, queryParams);

            ClassTracer.DebugFormat("Request [GET] to url '{0}{1}'", BaseAddressServices, route);
            var responseContent = await PerformWebClientAction(client => client.GetAsync(route), token);
            string responseContentString = await responseContent.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContentString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }

        protected async Task Post(string url, object value, string token, NameValueCollection queryParams = null)
        {
            string route = GetRoute(url, queryParams);

            ClassTracer.DebugFormat("Request [POST] to url '{0}{1}' with data '{2}'", BaseAddressServices, route, value);
            var postContent = CreateJsonContentFromObject(value);
            await PerformWebClientAction(client => client.PostAsync(route, postContent), token);
        }

        protected async Task<T> Post<T>(string url, object value, string token, NameValueCollection queryParams = null)
        {
            string route = GetRoute(url, queryParams);

            ClassTracer.DebugFormat("Request [POST] to url '{0}{1}' with data '{2}'", BaseAddressServices, route, value);
            var postContent = CreateJsonContentFromObject(value);
            var responseContent = await PerformWebClientAction(client => client.PostAsync(route, postContent), token);
            string responseContentString = await responseContent.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContentString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }

        /// <summary>
        /// Special handling for posting log messages as this must not log any further messages to prevent a loop.
        /// </summary>
        protected async Task PostLogMessage(string url, object value)
        {
            string route = GetRoute(url);
            var postContent = CreateJsonContentFromObject(value);
            using (var client = _httpClientFactory.GetClient())
            {
                SetRequestHeader(client);
                await client.PostAsync(route, postContent);
            }
        }

        private async Task<HttpResponseMessage> PerformWebClientAction(Func<HttpClient, Task<HttpResponseMessage>> action, string token)
        {
            using (var client = _httpClientFactory.GetClient())
            {
                SetRequestHeader(client);
                if(!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }    
                HttpResponseMessage response = null;
                try
                {
                    response = await action(client);
                }
                catch (Exception exception)
                {
                    // This catch block is not executed when there was an exception on the server,
                    // but only when there was a problem sending the request or receiving the answer.

                    ClassTracer.Error("Error when sending request to server", exception);
                }

                // If response is null => server was interupted
                if (response == null)
                {
                    throw new InternetInterupException(ExceptionConstants.ConnectExceptionString);
                }

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                string message;
                if (response.RequestMessage?.RequestUri != null)
                {
                    message = $"Web API service url '{response.RequestMessage.RequestUri}' returned error code: '{response.StatusCode}'";
                }
                else
                {
                    message = $"Web API service url returned error code: '{response.StatusCode}'";
                }

                // Encoding Json uft-8

                string responseContent = await response.Content.ReadAsStringAsync();

                //if (responseContent.Contains(typeof(ConcurrentUpdateException).FullName))
                //{
                //    var exception = JsonConvert.DeserializeObject<ConcurrentUpdateException>(responseContent);
                //    throw new ConcurrentUpdateException(exception.ExceptionMessage, exception);
                //}
                //else if (responseContent.Contains(typeof(ProjectAlreadyExistsException).FullName))
                //{
                //    var exception = JsonConvert.DeserializeObject<ProjectAlreadyExistsException>(responseContent);
                //    throw new ProjectAlreadyExistsException(exception.ExceptionMessage, exception);
                //}
                //else
                //{
                    message += $" & ResponseContent {responseContent}";
                    throw new SCMException(responseContent);
                //}
            }
        }

        private string GetRoute(string url, NameValueCollection queryParams = null)
        {
            string route = String.Format(RouteFormat, RoutePrefix, url).Trim('/');
            if (queryParams != null && queryParams.Count > 0)
            {
                route = $"{ route }?{ queryParams }";
            }

            return route;
        }

        protected void SetRequestHeader(HttpClient client)
        {
            client.BaseAddress = new Uri(BaseAddressServices);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));
        }

        protected StringContent CreateJsonContentFromObject(object value)
        {
            var content = JsonConvert.SerializeObject(value);
            var postContent = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, ApplicationJson);
            //var postContent = new StringContent(
            //    JsonConvert.SerializeObject(value, new JsonSerializerSettings
            //    {
            //        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            //        TypeNameHandling = TypeNameHandling.Objects
            //    }),
            //    Encoding.UTF8, ApplicationJson);
            return postContent;
        }
    }
}
