﻿using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OverviewViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.OverviewPageViewName;

        public void Construct()
        {
            throw new NotImplementedException();
        }
    }
}
