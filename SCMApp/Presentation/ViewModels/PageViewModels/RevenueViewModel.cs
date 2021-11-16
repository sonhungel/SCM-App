using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class RevenueViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.RevenuePageViewName;

        public string FunctionName => CommonConstants.RevenueFunctionName;

        public void Construct()
        {
        }
    }
}
