using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class PartnersViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.PartnersPageViewName;

        public void Construct()
        {
            throw new NotImplementedException();
        }
    }
}
