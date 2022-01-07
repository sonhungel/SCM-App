using SCMApp.Models;

namespace SCMApp.Presentation.ViewModels
{
    public interface IPageViewModel
    {
        bool IsLoaded { get; set; }
        string NamePage { get; }
        string FunctionName { get; }
        void Construct();
    }
}
