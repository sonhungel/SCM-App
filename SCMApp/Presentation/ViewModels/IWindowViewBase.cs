using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public interface IWindowViewBase
    {
        ICommand ICancelCommand { get; }
        ICommand ISaveCommand { get; }
    }
}
