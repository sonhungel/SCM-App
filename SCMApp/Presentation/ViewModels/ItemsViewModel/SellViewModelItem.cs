using SCMApp.Event_Delegate;
using SCMApp.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class SellViewModelItem: INotifyPropertyChanged
    {
        public SellViewModelItem(Item item, int orderNumber)
        {
            Model = item;
            OrderNumber = orderNumber;
            QuantityLeftInStock = item.availableQuantity;
            Quantity = 1;
        }
        public Item Model { get; set; }
        public int OrderNumber { get; set; }
        public int StockCode => Model.itemNumber;
        public string StockName => Model.name;
        public int Price => Model.salesPrice;
        public int TotalPrice => Model.salesPrice* _quantity;

        public int QuantityLeftInStock { get; set; }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < QuantityLeftInStock)
                {
                    _quantity = value;
                }
                else
                {
                    _quantity = QuantityLeftInStock;
                }    
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(IsVisiblePlusQuantity));
                OnPropertyChanged(nameof(TotalPrice));
                ReloadAfterCloseSubView.ReloadQuantityDelgate.Invoke(true);
            }
        }
        private void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                var msg = $"Invalid property name: {propertyName} ";

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }
        protected bool ThrowOnInvalidPropertyName
        {
            get;
            private set;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public Visibility IsVisiblePlusQuantity => Quantity < QuantityLeftInStock ? Visibility.Visible : Visibility.Hidden;

    }
}
