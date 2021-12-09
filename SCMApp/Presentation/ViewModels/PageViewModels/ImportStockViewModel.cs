using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ImportStockViewModel : ViewModelBase, IPageViewModel
    {
        public ImportStockViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
            OpenImportStockSubViewCommand = new RelayCommand(p => OpenImportStockSubView());
        }

        public ICommand OpenImportStockSubViewCommand { get; set; }

        public string NamePage => CommonConstants.ImportPageViewName;

        public string FunctionName => CommonConstants.ImportFunctionName;

        private bool _isHaveNoData;

        public bool IsHaveNoData
        {
            get => _isHaveNoData;
            set
            {
                _isHaveNoData = value;
                OnPropertyChanged(nameof(IsHaveNoData));
            }
        }

        public void Construct()
        {
        }

        private void OpenImportStockSubView()
        {
            ScreenManager.ShowImportStockView(View);
        }
    }
}
