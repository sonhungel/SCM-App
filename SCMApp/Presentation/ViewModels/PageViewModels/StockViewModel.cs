using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class StockViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.StockPageViewName;

        public void Construct()
        {
            throw new NotImplementedException();
        }
    }
}
