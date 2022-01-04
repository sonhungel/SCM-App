using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class PartnersViewModel : ViewModelBase, IPageViewModel
    {
        public PartnersViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            OpenCustomerViewCommand = new RelayCommand(p => OpenCustomerView());
            OpenPartnerViewCommand = new RelayCommand(p => OpenPartnerView());

            CustomerList = new ObservableCollection<CustomerViewModelItem>() { new CustomerViewModelItem(new Customer()) };
            PartnerList = new ObservableCollection<PartnerViewModelItem>() { new PartnerViewModelItem(new Partner()) };

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

        public void Construct()
        {
        }

        private void OpenCustomerView()
        {
            ScreenManager.ShowCustomerDetailView(View,Token);
        }

        private void OpenPartnerView()
        {
            ScreenManager.ShowPartnerDetailView(View,Token);
        }

        private void EditCustomer(string customerCode)
        {
            ScreenManager.ShowCustomerDetailView(View, Token);
        }
        private void DeleteCustomer(string customerCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá khách hàng này ra khỏi hệ thống ?", "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
            }
        }

        private void EditPartner(string partnerCode)
        {
            ScreenManager.ShowPartnerDetailView(View, Token);
        }
        private void DeletePartner(string partnerCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá đối tác này ra khỏi hệ thống ?", "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
            }
        }
    }
}
