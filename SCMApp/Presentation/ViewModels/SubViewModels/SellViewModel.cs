using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class SellViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IItemWebAPI _itemWebAPI;
        private readonly ICustomerWebAPI _customerWebAPI;
        private readonly IInvoiceWebAPI _invoiceWebAPI;
        public SellViewModel(IItemWebAPI itemWebAPI, ICustomerWebAPI customerWebAPI, IInvoiceWebAPI invoiceWebAPI
            , string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI = itemWebAPI;
            _customerWebAPI = customerWebAPI;
            _invoiceWebAPI = invoiceWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p =>
            {
                ValidateAllProperty();
                if (!HasErrors)
                {
                    SaveAction();
                }
            });
            MinusQuantityCommand = new RelayCommand(p => MinusQuantity((int)p));
            PlusQuantityCommand = new RelayCommand(p => PlusQuantity((int)p));

            SellListItem = new ObservableCollection<SellViewModelItem>();

            using (new WaitCursorScope())
            {
                ListCustomer = _customerWebAPI.GetAllCustomer(token);
                ListItem = _itemWebAPI.GetAllItem(token);
            }
            IsCreate = true;
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }
        public ICommand MinusQuantityCommand { get; }
        public ICommand PlusQuantityCommand { get; }

        public IList<Item> ListItem { get; set; }
        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (SellListItem.Any(x => x.StockCode == value.itemNumber))
                {
                    return;
                }
                if (SellListItem.Any())
                {
                    var newItemToAdd = new SellViewModelItem(value, SellListItem.LastOrDefault().OrderNumber + 1);
                    SellListItem.Add(newItemToAdd);
                }
                else
                {
                    var newItemToAdd = new SellViewModelItem(value, 1);
                    SellListItem.Add(newItemToAdd);
                }
                OnPropertyChangedNoInput();
                OnPropertyChanged(nameof(TotalMoney));
                OnPropertyChanged(nameof(TotalQuantityOfStock));
            }
        }

        public ObservableCollection<SellViewModelItem> SellListItem { get; set; }
        public IList<Customer> ListCustomer { get; set; }
        public Customer SelectedCustomer { get; set; }

        public int? TotalQuantityOfStock
        {
            get
            {
                int quantity = 0;
                var quantityList = SellListItem.Select(x => x.Quantity).ToList();
                quantityList.ForEach(x =>
                {
                    quantity += x;
                });
                return quantity == 0 ? null : quantity;
            }
        }

        public int? TotalMoney
        {
            get
            {
                int totalMoney = 0;
                var totalMoneyList = SellListItem.Select(x => x.TotalPrice).ToList();
                totalMoneyList.ForEach(x =>
                {
                    totalMoney += x;
                });
                return totalMoney == 0 ? null : totalMoney;
            }
        }
        public int? MoneyPaidBackForCustomer
        {
            get
            {
                int moneyPayBackForCustomer = 0;
                if(MoneyCustomerPaid.HasValue && TotalMoney.HasValue && MoneyCustomerPaid.Value!=0)
                {
                    moneyPayBackForCustomer = MoneyCustomerPaid.Value - TotalMoney.Value;
                }    
                return moneyPayBackForCustomer;

            }
        }
        // need to validation
        private int? _moneyCustomerPaid;
        public int? MoneyCustomerPaid
        {
            get => _moneyCustomerPaid.HasValue ? _moneyCustomerPaid.Value : null;
            set
            {
                if(!value.HasValue)
                {
                    return;
                }    
                _moneyCustomerPaid = value.Value;
                OnPropertyChangedNoInput();
                OnPropertyChanged(nameof(MoneyPaidBackForCustomer));
            }
        }

        public string Note
        {
            get;
            set;
        }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(SellListItem));
            CleanUpError(nameof(SelectedCustomer));
            CleanUpError(nameof(MoneyCustomerPaid));

            if (SellListItem.Count <= 0)
            {
                AddError(nameof(SellListItem), "Phải chọn ít nhất 1 mặt hàng.");
            }
            if (SelectedCustomer == null)
            {
                AddError(nameof(SelectedCustomer), "Vui lòng chọn khách hàng");
            }
            if (!MoneyCustomerPaid.HasValue)
            {
                AddError(nameof(MoneyCustomerPaid), "Nhập số tiền khách trả.");
            }
            if(MoneyCustomerPaid.HasValue && TotalMoney != 0 && MoneyCustomerPaid.Value < TotalMoney)
            {
                AddError(nameof(MoneyCustomerPaid), "Số tiền không hợp lệ.");
            }    
        }

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {
            var listInvoiceDetail = new List<CreateInvoiceDetailDTO>();
            foreach (var sellItem in SellListItem)
            {
                var invoiceDetail = new CreateInvoiceDetailDTO()
                {
                    itemNumber = sellItem.StockCode,
                    quantity = sellItem.Quantity,
                    price = sellItem.Price,
                    discount = 0
                };
                listInvoiceDetail.Add(invoiceDetail);
            }
            var invoice = new CreateInvoiceDTO()
            {
                customer = new CustomerNumber() { customerNumber = SelectedCustomer.customerNumber.Value },
                invoiceDetailDtoList = listInvoiceDetail
            };
            using (new WaitCursorScope())
            {
                var r = _invoiceWebAPI.CreateInvoice(invoice, Token);
            }
            View.Close();
        }

        private void MinusQuantity(int orderNumber)
        {
            var item = SellListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá mặt hàng này ra hỏi hoá đơn ?",
                       "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    SellListItem.Remove(item);
                }
            }
            OnPropertyChanged(nameof(SellListItem));
            OnPropertyChanged(nameof(TotalMoney));
            OnPropertyChanged(nameof(TotalQuantityOfStock));
        }

        private void PlusQuantity(int orderNumber)
        {
            var item = SellListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null)
            {
                item.Quantity++;
            }
            OnPropertyChanged(nameof(SellListItem));
            OnPropertyChanged(nameof(TotalMoney));
            OnPropertyChanged(nameof(TotalQuantityOfStock));
        }
    }
}
