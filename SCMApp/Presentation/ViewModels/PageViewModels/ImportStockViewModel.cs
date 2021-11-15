using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ImportStockViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.ImportPageViewName;

        public void Construct()
        {
            throw new NotImplementedException();
        }
    }
}
