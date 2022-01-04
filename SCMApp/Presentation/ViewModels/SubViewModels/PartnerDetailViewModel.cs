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
            get => Model.PartnerName;
            set
            {
                Model.PartnerName = value;
                OnPropertyChanged(nameof(PartnerFullName));
            }
        }
        public string PartnerCode
        {
            get => Model.PartnerCode;
            set
            {
                Model.PartnerCode = value;
                OnPropertyChanged(nameof(PartnerCode));
            }
        }
        public string PartnerPhoneNumber
        {
            get => Model.PartnerPhoneNumber;
            set
            {
                Model.PartnerPhoneNumber = value;
                OnPropertyChanged(nameof(PartnerPhoneNumber));
            }
        }
        public string PartnerEmail
        {
            get => Model.PartnerEmail;
            set
            {
                Model.PartnerEmail = value;
                OnPropertyChanged(nameof(PartnerEmail));
            }
        }
        public string TaxCode
        {
            get => Model.TaxCode;
            set
            {
                Model.TaxCode = value;
                OnPropertyChanged(nameof(TaxCode));
            }
        }

        public List<string> PartnerType { get; set; }
        public string SelectedPartnerType { get; set; }

        public string StreetAddress
        {
            get => Model.StreetAddress;
            set
            {
                Model.StreetAddress = value;
                OnPropertyChanged(nameof(StreetAddress));
            }
        }

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        public Province SelectedProvince
        {
            get => Model.ProvinceAddress;
            set
            {
                if (value == null)
                    return;
                Model.ProvinceAddress = value;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get => Model.DistrictAddress;
            set
            {
                if (value == null)
                    return;
                Model.DistrictAddress = value;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard 
        {
            get => Model.WardAddress;
            set
            {
                Model.WardAddress = value;
                OnPropertyChanged(nameof(SelectedWard));
            }
        }

        public string Note
        {
            get => Model.Note;
            set
            {
                Model.Note = value;
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
