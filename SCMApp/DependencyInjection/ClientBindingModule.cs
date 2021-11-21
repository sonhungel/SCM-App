using Ninject.Modules;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient;

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
            //Bind<IProjectWebApiClient>().To<ProjectWebApiClient>().InSingletonScope();
            //Bind<IGroupWebApiClient>().To<GroupWebApiClient>().InSingletonScope();
            //Bind<IEmployeeWebApiClient>().To<EmployeeWebApiClient>().InSingletonScope();
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
