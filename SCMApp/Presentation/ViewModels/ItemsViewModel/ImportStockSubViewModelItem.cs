using SCMApp.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class ImportStockSubViewModelItem: INotifyPropertyChanged
    {
        public ImportStockSubViewModelItem()
        { 
            Quantity = 12;
        }
        public int OrderNumber { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        private int _quantity;
        public int Quantity 
        { 
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

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
