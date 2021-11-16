﻿using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ProfitViewModel : ViewModelBase, IPageViewModel
    {
        public string NamePage => CommonConstants.ProfitPageViewName;

        public string FunctionName => CommonConstants.ProfitFunctionName;

        public void Construct()
        {
        }
    }
}
