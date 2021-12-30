using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System.Collections.Generic;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class PartnerDetailViewModel : ViewModelBase, IWindowViewBase
    {
        public PartnerDetailViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ProvinceList = Address.Instance().ProvinceList;
            PartnerType = new List<string>() { "Doanh nghiệp", "Cá nhân" };
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public List<string> PartnerType { get; set; }
        public string SelectedPartnerType { get; set; }

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        private Province _selectedProvince { get; set; }
        private District _selectedDistrict { get; set; }

        public Province SelectedProvince
        {
            get => _selectedProvince;
            set
            {
                if (value == null)
                    return;
                _selectedProvince = value;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get => _selectedDistrict;
            set
            {
                if (value == null)
                    return;
                _selectedDistrict = value;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
