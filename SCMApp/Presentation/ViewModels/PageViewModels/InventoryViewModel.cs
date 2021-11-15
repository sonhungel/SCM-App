using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class InventoryViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.InventoryPageViewName;

        public void Construct()
        {
            throw new NotImplementedException();
        }
    }
}
