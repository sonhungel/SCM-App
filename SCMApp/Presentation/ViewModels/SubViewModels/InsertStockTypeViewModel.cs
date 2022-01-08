using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InsertStockTypeViewModel : ViewModelBase, IWindowViewBase
    {
        public InsertStockTypeViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            Model = new ItemType(0,"");
        }

        private ItemType Model;
        public int StockTypeCode => Model.id;
        
        public string StockTypeName 
        {
            get => Model.typeName;
            set
            {
                Model.typeName = value;
                OnPropertyChanged(nameof(StockTypeName));
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
