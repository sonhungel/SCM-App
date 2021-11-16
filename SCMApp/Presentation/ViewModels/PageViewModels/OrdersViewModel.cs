using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OrdersViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.OrdersPageViewName;

        public string FunctionName => CommonConstants.OrdersFunctionName;

        public void Construct()
        {
        }
    }
}
