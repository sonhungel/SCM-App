using SCMApp.Constants;
using SCMApp.Event_Delegate;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System.Collections.Generic;
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
        private readonly IItemWebAPI _itemWebAPI;
        public PartnersViewModel(IItemWebAPI itemWebAPI, ICustomerWebAPI customerWebAPI, IPartnerWebAPI partnerWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _customerWebAPI = customerWebAPI;
            _partnerWebAPI = partnerWebAPI;
            _itemWebAPI = itemWebAPI;
            OpenCustomerViewCommand = new RelayCommand(p => OpenCustomerView());
            OpenPartnerViewCommand = new RelayCommand(p => OpenPartnerView());

            CustomerList = new ObservableCollection<CustomerViewModelItem>();
            PartnerList = new ObservableCollection<PartnerViewModelItem>();

            EditCustomerCommand = new RelayCommand(p => EditCustomer((int)p));
            DeleteCustomerCommand = new RelayCommand(p => DeleteCustomer((int)p));

            EditPartnerCommand = new RelayCommand(p => EditPartner((int)p));
            DeletePartnerCommand = new RelayCommand(p => DeletePartner((int)p));

            _listAllItem = _itemWebAPI.GetAllItem(token);
            _listSupplierOfInAllItem = _listAllItem.Select(x => x.supplier).DistinctBy(x => x.supplierNumber).ToList();
            ReloadAfterCloseSubView.ConfirmDeleteSupplier = ConfirmDeleteSupplier;
        }

        public ICommand OpenCustomerViewCommand { get; set; }
        public ICommand OpenPartnerViewCommand { get; set; }

        public ObservableCollection<CustomerViewModelItem> CustomerList { get; set; }
        public int CustomerNumber => CustomerList.Count();
        public ObservableCollection<PartnerViewModelItem> PartnerList { get; set; }
        public int PartnerNumber => PartnerList.Count();

        private IList<Partner> _listSupplierOfInAllItem;
        private IList<Item> _listAllItem;

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
            OnPropertyChanged(nameof(PartnerNumber));
            OnPropertyChanged(nameof(CustomerNumber));
        }

        private void OpenCustomerView()
        {
            ScreenManager.ShowCustomerDetailView(View, null, true, Token);
        }

        private void OpenPartnerView()
        {
            ScreenManager.ShowPartnerDetailView(View, null, true, Token); ;
        }

        private void EditCustomer(int customerCode)
        {
            var customerUpdate = CustomerList.SingleOrDefault(x => x.CustomerCode == customerCode).Model;
            ScreenManager.ShowCustomerDetailView(View, customerUpdate, false, Token);
        }
        private void DeleteCustomer(int customerCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View, "Bạn có muốn xoá khách hàng này ra khỏi hệ thống ?",
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                using (new WaitCursorScope())
                {
                    var result = _customerWebAPI.DeleteCustomer(customerCode.ToString(), Token);
                    ReloadAfterCloseSubView.Instance.Invoke(result);
                }
            }
        }

        private void EditPartner(int partnerCode)
        {
            var partner = PartnerList.SingleOrDefault(x => x.PartnerCode == partnerCode).Model;
            ScreenManager.ShowPartnerDetailView(View, partner, false, Token);
        }
        private void DeletePartner(int partnerCode)
        {

            if (_listSupplierOfInAllItem.Any(x => x.id == partnerCode))
            {
                _confirmDeleteSupplier = false;
                using (var wait = new WaitCursorScope())
                {
                    var listItemOfSupplier = _listAllItem.Where(x => x.supplier.id == partnerCode).ToList();
                    wait.PauseWaitCursor();
                    ScreenManager.ShowWarningDeleteSupplier(listItemOfSupplier, View, Token);
                    if (_confirmDeleteSupplier)
                    {
                        //var result = _partnerWebAPI.DeleteSupplier(partnerCode.ToString(), Token);
                        //ReloadAfterCloseSubView.Instance.Invoke(result);
                    }
                }
            }
            else
            {
                using (new WaitCursorScope())
                {
                    //var result = _partnerWebAPI.DeleteSupplier(partnerCode.ToString(), Token);
                    //ReloadAfterCloseSubView.Instance.Invoke(result);
                }
            }

        }

        private bool _confirmDeleteSupplier;

        private void ConfirmDeleteSupplier(bool confirm)
        {
            _confirmDeleteSupplier = confirm;
        }
    }
}
