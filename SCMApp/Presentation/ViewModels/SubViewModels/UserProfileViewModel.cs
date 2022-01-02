using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class UserProfileViewModel : ViewModelBase, IWindowViewBase
    {
        public UserProfileViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ProvinceList = Address.Instance().ProvinceList;
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public UserProfile Model { get; set; }

        public string UserFullName
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                OnPropertyChanged(nameof(UserFullName));
            }
        }
        public string UserName
        {
            get => Model.UserName;
            set
            {
                Model.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string UserEmail
        {
            get => Model.Email;
            set
            {
                Model.Email = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }
        public string UserPhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                Model.PhoneNumber = value;
                OnPropertyChanged(nameof(UserPhoneNumber));
            }
        }
        public string CurrentPassWord
        {
            get => Model.Password;
            set
            {
                Model.Password = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }
        public string NewPassword
        {
            get;
            set;
        }
        public string VerifyPassword
        {
            get => Model.VerifyPassword;
            set
            {
                Model.VerifyPassword = value;
                OnPropertyChanged(nameof(VerifyPassword));
            }
        }
        public DateTime? UserBirthDay { get; set; }
        public string UserRole  => Model.Title;

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

        public string StreetAddress
        {
            get => Model.StreetAddress;
            set
            {
                Model.StreetAddress = value;
                OnPropertyChanged(nameof(StreetAddress));
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
