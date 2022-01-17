using SCMApp.Event_Delegate;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class WarningViewModel : SubViewModelBase, IWindowViewBase
    {
        public WarningViewModel(IList<Item> items,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            StockList = new ObservableCollection<StockViewModelItem>();
            foreach (var item in items)
            {
                StockList.Add(new StockViewModelItem(item));
            }
            WarningName = @"Nhà cung cấp bạn muốn xoá hiện tại đang là người cung cấp tới một số mặt hàng trong hệ thống. 
Hãy chắc chắn bạn sẽ không đứt gãy chuỗi cung cấp hàng hoá nếu xoá nhà cung cấp này khỏi hệ thống!
Trong trường hợp bạn muốn tìm một nhà cung cấp mới cho mặt hàng này, hãy tạo lại mặt hàng và lựa chọn nhà cung cấp mới";
        }

        private void SaveAction()
        {
            ReloadAfterCloseSubView.ConfirmDeleteSupplier.Invoke(true);
            View.Close();
        }

        private void CancelAction()
        {
            View.Close();
        }

        public ICommand ICancelCommand { get; }

        public ICommand ISaveCommand { get; }

        public bool IsCreate { get; set; }

        public ObservableCollection<StockViewModelItem> StockList { get; set; }

        public string WarningName { get; set; }
    }
}
