using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class PartnersViewModel : ViewModelBase, IPageViewModel
    {
        public PartnersViewModel(IScreenManager screenManager) : base(screenManager)
        {
            OpenCustomerViewCommand = new RelayCommand(p => OpenCustomerView());
            OpenPartnerViewCommand = new RelayCommand(p => OpenPartnerView());
        }

        public ICommand OpenCustomerViewCommand { get; set; }
        public ICommand OpenPartnerViewCommand { get; set; }

        public string NamePage => CommonConstants.PartnersPageViewName;

        public string FunctionName => CommonConstants.PartnersFunctionName;

        public void Construct()
        {
        }

        private void OpenCustomerView()
        {
            ScreenManager.ShowCustomerDetailView(View);
        }

        private void OpenPartnerView()
        {
            ScreenManager.ShowPartnerDetailView(View);
        }
    }
}
