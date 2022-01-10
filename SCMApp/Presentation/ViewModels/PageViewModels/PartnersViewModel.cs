using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class PartnersViewModel : ViewModelBase, IPageViewModel
    {
        private readonly ICustomerWebAPI _customerWebAPI;
        private readonly IPartnerWebAPI _partnerWebAPI;
        public PartnersViewModel(ICustomerWebAPI customerWebAPI, IPartnerWebAPI partnerWebAPI, 
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _customerWebAPI = customerWebAPI;
            _partnerWebAPI = partnerWebAPI;
            OpenCustomerViewCommand = new RelayCommand(p => OpenCustomerView());
            OpenPartnerViewCommand = new RelayCommand(p => OpenPartnerView());

            CustomerList = new ObservableCollection<CustomerViewModelItem>();
            PartnerList = new ObservableCollection<PartnerViewModelItem>();

            EditCustomerCommand = new RelayCommand(p => EditCustomer((string)p));
            DeleteCustomerCommand = new RelayCommand(p => DeleteCustomer((string)p));

            EditPartnerCommand = new RelayCommand(p => EditPartner((string)p));
            DeletePartnerCommand = new RelayCommand(p => DeletePartner((string)p));
        }

        public ICommand OpenCustomerViewCommand { get; set; }
        public ICommand OpenPartnerViewCommand { get; set; }

        public ObservableCollection<CustomerViewModelItem> CustomerList { get; set; }
        public ObservableCollection<PartnerViewModelItem> PartnerList { get; set; }

        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand EditPartnerCommand { get; set; }
        public ICommand DeletePartnerCommand { get; set; }

        public string NamePage => CommonConstants.PartnersPageViewName;

        public string FunctionName => CommonConstants.PartnersFunctionName;

        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            PartnerList.Clear();
            CustomerList.Clear();
            using (new WaitCursorScope())
            {
                var allCustomer = _customerWebAPI.GetAllCustomer(Token);
                foreach (var customer in allCustomer)
                {
                    CustomerList.Add(new CustomerViewModelItem(customer));
                }
                var allPartner = _partnerWebAPI.GetAllSupplier(Token);
                foreach (var partner in allPartner)
                {
                    PartnerList.Add(new PartnerViewModelItem(partner));
                }
            }
        }

        private void OpenCustomerView()
        {
            ScreenManager.ShowCustomerDetailView(View, null, true, Token);
        }

        private void OpenPartnerView()
        {
            ScreenManager.ShowPartnerDetailView(View,null,true,Token); ;
        }

        private void EditCustomer(string customerCode)
        {
            var customerUpdate = CustomerList.SingleOrDefault(x => x.CustomerCode == customerCode).Model;
            ScreenManager.ShowCustomerDetailView(View, customerUpdate,false, Token);
        }
        private void DeleteCustomer(string customerCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá khách hàng này ra khỏi hệ thống ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
            }
        }

        private void EditPartner(string partnerCode)
        {
            var partner = PartnerList.SingleOrDefault(x => x.PartnerCode == partnerCode).Model;
            ScreenManager.ShowPartnerDetailView(View,partner,false, Token);
        }
        private void DeletePartner(string partnerCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View, "Bạn có muốn xoá đối tác này ra khỏi hệ thống ?",
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
            }
        }
    }
}
