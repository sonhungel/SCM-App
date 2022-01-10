using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public interface IWindowViewBase
    {
        ICommand ICancelCommand { get; }
        ICommand ISaveCommand { get; }
        bool IsCreate { get; set; }
    }
}
