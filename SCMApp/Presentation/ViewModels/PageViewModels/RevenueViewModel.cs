using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class RevenueViewModel : ViewModelBase, IPageViewModel
    {
        public RevenueViewModel(IScreenManager screenManager) : base(screenManager)
        {

        }
        public string NamePage => CommonConstants.RevenuePageViewName;

        public string FunctionName => CommonConstants.RevenueFunctionName;

        public void Construct()
        {
        }
    }
}
