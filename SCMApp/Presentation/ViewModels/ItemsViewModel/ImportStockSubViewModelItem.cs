using SCMApp.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class ImportStockSubViewModelItem: INotifyPropertyChanged
    {
        public ImportStockSubViewModelItem(Item item, int orderNumber)
        {
            Model = item;
            OrderNumber = orderNumber;
            _quantity = 1;
        }
        public Item Model;
        public int OrderNumber { get; set; }
        public int StockCode => Model.itemNumber;
        public string StockName => Model.name;
        private int _quantity;
        public int Quantity 
        { 
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public decimal Price => Model.cost;
        public decimal TotalPrice => Model.cost * _quantity;

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
    }
}
