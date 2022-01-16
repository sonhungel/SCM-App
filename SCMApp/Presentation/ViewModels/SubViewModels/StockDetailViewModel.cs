using SCMApp.Event_Delegate;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class StockDetailViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IItemTypeWebAPI _itemTypeWebAPI;
        private readonly IPartnerWebAPI _partnerWebAPI;
        private readonly IItemWebAPI _itemWebAPI;
        public StockDetailViewModel(IItemTypeWebAPI itemTypeWebAPI, IPartnerWebAPI partnerWebAPI, IItemWebAPI itemWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemTypeWebAPI = itemTypeWebAPI;
            _partnerWebAPI = partnerWebAPI;
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
                ItemTypes = _itemTypeWebAPI.GetAllItemType(Token);
                Partners = _partnerWebAPI.GetAllSupplier(Token);
            }
            Model = new Item();
            IsCreate = true;
        }    

        public Item Model { get; set; }

        public string StockName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(StockName));
            }
        }
        public int? StockCode
        {
            get => Model.itemNumber == 0 ? null : Model.itemNumber;
            set
            {
                if (!value.HasValue)
                    return;
                Model.itemNumber = value.Value;
                OnPropertyChanged(nameof(StockCode));
            }
        }

        public IList<ItemType> ItemTypes { get; set; }
        public ItemType SelectedItemType 
        {
            get => Model.itemType;
            set
            {
                Model.itemType = value;
                OnPropertyChangedNoInput();
            }
        }
        public string SelectedParterName => Model.supplier?.name;

        public IList<Partner> Partners { get; set; }
        public Partner SelectedPartner
        {
            get => Model.supplier;

            set
            {
                Model.supplier = value;
                OnPropertyChangedNoInput();
            }
        }
        public int? StockCost
        {
            get => Model.cost == 0 ? null :Model.cost;
            set
            {
                if (!value.HasValue)
                    return;
                Model.cost = value.Value;
                OnPropertyChanged(nameof(StockCost));
            }
        }
        public int? StockRetailPrice
        {
            get => Model.salesPrice == 0 ? null :Model.salesPrice;
            set
            {
                if (!value.HasValue)
                    return;
                Model.salesPrice = value.Value;
                OnPropertyChanged(nameof(StockRetailPrice));
            }
        }
        public string SupplierName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(SupplierName));
            }
        }
        public int? StockInventoryQuantity
        {
            get => Model.quantity == 0 ? null :Model.quantity;
            set
            {
                if (!value.HasValue)
                    return;
                Model.quantity = value.Value;
                OnPropertyChanged(nameof(StockInventoryQuantity));
            }
        }

        public int? StockMinInventoryQuantity
        {
            get => Model.minimumQuantity == 0 ? null :Model.minimumQuantity;
            set
            {
                if (!value.HasValue)
                    return;
                Model.minimumQuantity = value.Value;
                OnPropertyChanged(nameof(StockMinInventoryQuantity));
            }
        }
        public string StockDescription
        {
            get => Model.description;
            set
            {
                Model.description = value;
                OnPropertyChanged(nameof(StockDescription));
            }
        }
        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        public Visibility isShowTextBox => IsCreate ? Visibility.Hidden : Visibility.Visible;

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(StockName));
            CleanUpError(nameof(StockCost));
            CleanUpError(nameof(SelectedItemType));
            CleanUpError(nameof(StockRetailPrice));
            CleanUpError(nameof(SelectedPartner));
            CleanUpError(nameof(StockInventoryQuantity));
            CleanUpError(nameof(StockMinInventoryQuantity));


            if (string.IsNullOrEmpty(StockName))
            {
                AddError(nameof(StockName), "Tên sản phẩm không được trống.");
            }
            if (!StockCost.HasValue)
            {
                AddError(nameof(StockCost), "Giá vốn không được trống.");
            }
            if (!StockRetailPrice.HasValue)
            {
                AddError(nameof(StockRetailPrice), "Giá bán không được trống.");
            }
            if (StockRetailPrice.HasValue && StockCost.HasValue && StockCost > StockRetailPrice)
            {
                AddError(nameof(StockRetailPrice), "Giá vốn đang cao hơn giá bán.");
            }
            if(SelectedItemType == null)
            {
                AddError(nameof(SelectedItemType), "Không được trống nhóm hàng.");
            }   
            if(SelectedPartner == null)
            {
                AddError(nameof(SelectedPartner), "Không được trống nhà cung cấp.");
            }   
            if(!StockInventoryQuantity.HasValue)
            {
                AddError(nameof(StockInventoryQuantity), "Số lượng hàng không được trống.");
            }   
            if(!StockMinInventoryQuantity.HasValue)
            {
                AddError(nameof(StockMinInventoryQuantity), "Số lượng tối thiểu không được trống.");
            }
            if (StockInventoryQuantity.HasValue && StockMinInventoryQuantity.HasValue && StockMinInventoryQuantity > StockInventoryQuantity)
            {
                AddError(nameof(StockMinInventoryQuantity), "Số lượng không hợp lệ.");
            }
        }

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {
            if(IsCreate)
            {
                using (new WaitCursorScope())
                {
                    var createItem = new CreateItemDTO()
                    {
                        itemNumber = Model.itemNumber == 0 ? null : Model.itemNumber,
                        name = Model.name,
                        itemType = new ItemtypeNumber(Model.itemType.id),
                        cost = Model.cost,
                        salesPrice = Model.salesPrice,
                        quantity = Model.quantity,
                        minimumQuantity = Model.minimumQuantity,
                        supplier = new SupplierNumber(Model.supplier.supplierNumber.Value),
                        description = Model.description,
                        remark = Model.remark
                    };
                    var result = _itemWebAPI.CreateItem(createItem, Token);
                    ReloadAfterCloseSubView.Instance.Invoke(result);
                }
            }    
            else
            {
                using (new WaitCursorScope())
                {
                    var updateItem = new UpdateItemDTO()
                    {
                        itemNumber = Model.itemNumber,
                        name = Model.name,
                        cost = Model.cost,
                        salesPrice = Model.salesPrice,
                        minimumQuantity = Model.minimumQuantity,
                        version = Model.version
                    };
                    var result = _itemWebAPI.UpdateItem(updateItem, Token);
                    ReloadAfterCloseSubView.Instance.Invoke(result);
                }
            }    
            
            View.Close();
        }
    }
}
