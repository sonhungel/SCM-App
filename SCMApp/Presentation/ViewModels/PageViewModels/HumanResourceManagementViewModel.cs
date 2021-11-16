using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    class HumanResourceManagementViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.HRMPageViewName;

        public string FunctionName => CommonConstants.HRMFunctionName;

        public void Construct()
        {
        }
    }
}
