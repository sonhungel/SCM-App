using Ninject.Modules;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient;
using SCMApp.WebAPIClient.MainView;

namespace SCMApp.DependencyInjection
{
    public class ClientBindingModule : NinjectModule
    {
        public override void Load()
        {
            BindWebApiClients();
            BindTransportLayer();
            BindViewLayer();
        }

        private void BindWebApiClients()
        {
            Bind<ILoginWebAPI>().To<LoginWebAPI>().InSingletonScope();
        }

        private void BindTransportLayer()
        {
            Bind<IHttpClientFactory>().To<HttpClientFactory>().InSingletonScope();
        }
        private void BindViewLayer()
        {
            Bind<IScreenManager>().To<ScreenManager>().InSingletonScope();
        }
    }
}
