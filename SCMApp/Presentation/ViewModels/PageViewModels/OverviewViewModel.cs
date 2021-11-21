using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OverviewViewModel : ViewModelBase, IPageViewModel
    {
        public OverviewViewModel(IScreenManager screenManager) : base(screenManager)
        {

        }
        public string NamePage => CommonConstants.OverviewPageViewName;

        public string FunctionName => CommonConstants.OverviewFunctionName;

        public void Construct()
        {
        }
    }
}
