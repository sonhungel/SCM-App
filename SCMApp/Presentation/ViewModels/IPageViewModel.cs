﻿using SCMApp.Models;

namespace SCMApp.Presentation.ViewModels
{
    public interface IPageViewModel
    {
        string NamePage { get; }
        string FunctionName { get; }
        void Construct();
    }
}
