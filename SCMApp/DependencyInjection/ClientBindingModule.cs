using Ninject.Modules;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.PageViewAPIs;

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
            Bind<IUserWebAPI>().To<UserWebAPI>().InSingletonScope();
            Bind<IItemTypeWebAPI>().To<ItemTypeWebAPI>().InSingletonScope();
            Bind<IItemWebAPI>().To<ItemWebAPI>().InSingletonScope();
            Bind<ICustomerWebAPI>().To<CustomerWebAPI>().InSingletonScope();
            Bind<IPartnerWebAPI>().To<PartnerWebAPI>().InSingletonScope();
            Bind<IProfitWebAPI>().To<ProfitWebAPI>().InSingletonScope();
            Bind<IInventoryWebAPI>().To<InventoryWebAPI>().InSingletonScope();
            Bind<IInvoiceWebAPI>().To<InvoiceWebAPI>().InSingletonScope();
            Bind<IImportStockWebAPI>().To<ImportStockWebAPI>().InSingletonScope();
        }

        private void BindTransportLayer()
        {
            Bind<IHttpClientFactory>().To<HttpClientFactory>().InSingletonScope();
        }
        private void BindViewLayer()
        {
            Bind<IScreenManager>().To<ScreenManager>().InSingletonScope();
            Bind<IWaitCursorScope>().To<WaitCursorScopeImpl>();
        }
    }
}
