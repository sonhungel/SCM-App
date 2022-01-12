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
            ISaveCommand = new RelayCommand(p => SaveAction());

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

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        protected override void ValidateProperty()
        {

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
                var createItem = new CreateItemDTO()
                {
                    itemNumber = Model.itemNumber,
                    name = Model.name,
                    itemType = new ItemtypeNumber(Model.itemType.id),
                    cost = Model.cost,
                    salesPrice = Model.salesPrice,
                    quantity = Model.quantity,
                    minimumQuantity = Model.minimumQuantity,
                    supplier = new SupplierNumber(Model.supplier.id),
                    description = Model.description,
                    remark = Model.remark
                };
                var r = _itemWebAPI.CreateItem(createItem,Token);
            }
            View.Close();
        }
    }
}
