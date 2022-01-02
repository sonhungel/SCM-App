﻿using SCMApp.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class SellViewModelItem: INotifyPropertyChanged
    {
        public SellViewModelItem()
        {
            QuantityLeftInStock = 12;
            Quantity = 1;
        }
        public int OrderNumber { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

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