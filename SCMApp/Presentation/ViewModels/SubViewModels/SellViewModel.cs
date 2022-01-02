using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class SellViewModel : ViewModelBase, IWindowViewBase
    {
        public SellViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            MinusQuantityCommand = new RelayCommand(p => MinusQuantity((int)p));
            PlusQuantityCommand = new RelayCommand(p => PlusQuantity((int)p));

            SellListItem = new ObservableCollection<SellViewModelItem>()
            {
                new SellViewModelItem()
            };
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }
        public ICommand MinusQuantityCommand { get; }
        public ICommand PlusQuantityCommand { get; }

        public ObservableCollection<SellViewModelItem> SellListItem { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

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
        }

        private void PlusQuantity(int orderNumber)
        {
            var item = SellListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null)
            {
                item.Quantity++;
            }
            OnPropertyChanged(nameof(SellListItem));
        }
    }
}
