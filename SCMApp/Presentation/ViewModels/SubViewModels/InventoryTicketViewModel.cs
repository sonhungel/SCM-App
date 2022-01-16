using SCMApp.Event_Delegate;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InventoryTicketViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IItemWebAPI _itemWebAPI;
        private readonly IInventoryWebAPI _inventoryWebAPI;
        public InventoryTicketViewModel(IItemWebAPI itemWebAPI, IInventoryWebAPI inventoryWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _inventoryWebAPI = inventoryWebAPI;
            _itemWebAPI = itemWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p =>
            {
                ValidateAllProperty();
                if (!HasErrors)
                {
                    SaveAction();
                }
            });

            using (new WaitCursorScope())
            {
                ListItem = _itemWebAPI.GetAllItem(Token);
            }    
            Model = new Inventory();
            _updateModel = new CreateInventoryDTO()
            {
                item = new ItemNumber()
            };
            IsCreate = true;
        }
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }
        public Inventory Model { get; set; }

        private CreateInventoryDTO _updateModel;
        public string ImportStockCode 
        { 
            get;
            set; 
        }

        public int? StockCode => SelectedItem?.itemNumber;
        public string StockName => SelectedItem?.name;
        public int? StockInventoryQuantity => SelectedItem?.availableQuantity;

        public IList<Item> ListItem { get; set; }
        public Item SelectedItem
        {
            get => Model.item;
            set
            {
                Model.item = value;
                _updateModel.item.itemNumber = value.itemNumber;
                OnPropertyChanged(nameof(StockCode));
                OnPropertyChanged(nameof(StockName));
                OnPropertyChanged(nameof(StockInventoryQuantity));
            }
        }

        public int? FactQuantity 
        {
            get => Model.availableQuantity == 0 ? null : Model.availableQuantity;
            set
            {
                if (value == null)
                    return;
                Model.availableQuantity = value.Value;
                _updateModel.availableQuantity = value.Value;
                OnPropertyChangedNoInput();
            }
        }
        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
                _updateModel.remark = value;
                OnPropertyChangedNoInput();
            }
        }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(SelectedItem));
            CleanUpError(nameof(FactQuantity));
            if(!FactQuantity.HasValue)
            {
                AddError(nameof(FactQuantity), "Số lượng thực tế không được trống.");
            }
            if(SelectedItem == null)
            {
                AddError(nameof(SelectedItem), "Phải chọn hàng hoá cần kiểm kho.");
            }
        }

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {
            using (new WaitCursorScope())
            {
                var result = _inventoryWebAPI.CreateInventoryTicket(_updateModel, Token);
                ReloadAfterCloseSubView.Instance.Invoke(result);
            }
            View.Close();
        }
    }
}
