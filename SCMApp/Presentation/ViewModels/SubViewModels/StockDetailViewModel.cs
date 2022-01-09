using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class StockDetailViewModel : ViewModelBase, IWindowViewBase
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
        public int StockCode
        {
            get => Model.itemNumber;
            set
            {
                Model.itemNumber = value;
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
        public int StockCost
        {
            get => Model.cost;
            set
            {
                Model.cost = value;
                OnPropertyChanged(nameof(StockCost));
            }
        }
        public int StockRetailPrice
        {
            get => Model.salesPrice;
            set
            {
                Model.salesPrice = value;
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
        public int StockInventoryQuantity
        {
            get => Model.quantity;
            set
            {
                Model.quantity = value;
                OnPropertyChanged(nameof(StockInventoryQuantity));
            }
        }

        public int StockMinInventoryQuantity
        {
            get => Model.minimumQuantity;
            set
            {
                Model.minimumQuantity = value;
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


        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
