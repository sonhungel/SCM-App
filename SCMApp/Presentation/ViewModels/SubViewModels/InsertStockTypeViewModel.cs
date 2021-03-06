using SCMApp.Event_Delegate;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InsertStockTypeViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IItemTypeWebAPI _itemTypeWebAPI;
        public InsertStockTypeViewModel(IItemTypeWebAPI itemTypeWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemTypeWebAPI = itemTypeWebAPI;
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
                Model = _itemTypeWebAPI.GetItemNewestId(Token);
            }
            IsCreate = true;
        }

        private ItemType Model;
        public int StockTypeCode => Model.id;
        
        public string StockTypeName 
        {
            get => Model.typeName == "INACTIVE"? string.Empty: Model.typeName;
            set
            {
                Model.typeName = value;
                OnPropertyChanged(nameof(StockTypeName));
            }
        }
        public string Note
        {
            get => Model.description;
            set
            {
                Model.description = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        public ICommand ICancelCommand { get; }

        public ICommand ISaveCommand { get; }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(StockTypeName));
            CleanUpError(nameof(Note));
            if (string.IsNullOrEmpty(StockTypeName))
            {
                AddError(nameof(StockTypeName), "Tên nhóm hàng không được trống.");
            }
            if (string.IsNullOrEmpty(Note))
            {
                AddError(nameof(Note), "Miêu tả không được trống.");
            }
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
                var result = _itemTypeWebAPI.CreateItemtype(Model,Token);
                ReloadAfterCloseSubView.Instance.Invoke(result);
            }
            View.Close();
        }
    }
}
