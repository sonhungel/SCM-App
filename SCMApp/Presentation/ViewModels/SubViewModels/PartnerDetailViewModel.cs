using SCMApp.Models;
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
        public PartnerDetailViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ProvinceList = Address.Instance().ProvinceList;
            PartnerType = new List<string>() { "Doanh nghiệp", "Cá nhân" };
            Model = new Partner();
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public Partner Model { get; set; }

        public string PartnerFullName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(PartnerFullName));
            }
        }
        public int PartnerCode
        {
            get => Model.id;
            set
            {
                Model.id = value;
                OnPropertyChanged(nameof(PartnerCode));
            }
        }
        public string PartnerPhoneNumber
        {
            get => Model.phoneNumber;
            set
            {
                Model.phoneNumber = value;
                OnPropertyChanged(nameof(PartnerPhoneNumber));
            }
        }
        public string PartnerEmail
        {
            get => Model.email;
            set
            {
                Model.email = value;
                OnPropertyChanged(nameof(PartnerEmail));
            }
        }
        public string TaxCode
        {
            get => Model.taxNumber;
            set
            {
                Model.taxNumber = value;
                OnPropertyChanged(nameof(TaxCode));
            }
        }

        public List<string> PartnerType { get; set; }
        public string SelectedPartnerType { get; set; }

        public string StreetAddress
        {
            get => Model.address;
            set
            {
                Model.address = value;
                OnPropertyChanged(nameof(StreetAddress));
            }
        }

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        public Province SelectedProvince
        {
            get => Model.province;
            set
            {
                if (value == null)
                    return;
                Model.province = value;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get => Model.district;
            set
            {
                if (value == null)
                    return;
                Model.district = value;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard 
        {
            get => Model.ward;
            set
            {
                Model.ward = value;
                OnPropertyChanged(nameof(SelectedWard));
            }
        }

        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
