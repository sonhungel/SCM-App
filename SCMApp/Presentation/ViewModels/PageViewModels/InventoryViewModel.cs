using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class InventoryViewModel : ViewModelBase, IPageViewModel
    {
        public InventoryViewModel(IScreenManager screenManager) : base(screenManager)
        {

        }
        public string NamePage => CommonConstants.InventoryPageViewName;

        public string FunctionName => CommonConstants.InventoryFunctionName;

        public void Construct()
        {
        }
    }
}
