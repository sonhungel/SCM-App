using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class PartnersViewModel : ViewModelBase, IPageViewModel
    {
        public PartnersViewModel(IScreenManager screenManager) : base(screenManager)
        {
            OpenCustomerViewCommand = new RelayCommand(p => OpenCustomerView());
            OpenPartnerViewCommand = new RelayCommand(p => OpenPartnerView());

            CustomerList = new ObservableCollection<CustomerViewModelItem>() { new CustomerViewModelItem(new Customer()) };
            PartnerList = new ObservableCollection<PartnerViewModelItem>() { new PartnerViewModelItem(new Partner()) };
        }

        public ICommand OpenCustomerViewCommand { get; set; }
        public ICommand OpenPartnerViewCommand { get; set; }

        public ObservableCollection<CustomerViewModelItem> CustomerList { get; set; }
        public ObservableCollection<PartnerViewModelItem> PartnerList { get; set; }
        public string NamePage => CommonConstants.PartnersPageViewName;

        public string FunctionName => CommonConstants.PartnersFunctionName;

        public void Construct()
        {
        }

        private void OpenCustomerView()
        {
            ScreenManager.ShowCustomerDetailView(View);
        }

        private void OpenPartnerView()
        {
            ScreenManager.ShowPartnerDetailView(View);
        }
    }
}
