using Ninject.Modules;
using SCMApp.WebAPIClient;

namespace SCMApp.DependencyInjection
{
    public class ClientBindingModule : NinjectModule
    {
        public override void Load()
        {
            BindWebApiClients();
            BindTransportLayer();
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

    }
}
