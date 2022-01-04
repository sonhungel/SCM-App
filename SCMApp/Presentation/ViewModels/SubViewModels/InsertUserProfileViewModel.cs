﻿using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InsertUserProfileViewModel : ViewModelBase, IWindowViewBase
    {
        public InsertUserProfileViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ProvinceList = Address.Instance().ProvinceList;
            Model = new UserProfile();
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        private UserProfile Model;

        public string UserFullName 
        {
            get => Model.fullName;
            set
            {
                Model.fullName = value;
                OnPropertyChanged(nameof(UserFullName));
            }
        }
        public string UserName
        {
            get => Model.username;
            set
            {
                Model.username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string UserEmail
        {
            get => Model.email;
            set
            {
                Model.email = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }
        public string UserPhoneNumber
        {
            get => Model.phoneNumber;
            set
            {
                Model.phoneNumber = value;
                OnPropertyChanged(nameof(UserPhoneNumber));
            }
        }

        public string Password
        {
            get => Model.password;
            set
            {
                Model.password = value;
                OnPropertyChanged(nameof(Password));
            }
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
        public IList<string> UserRole => CommonConstants.UserRole;
        public string SelectedUserRole { get; set; }

        public DateTime? UserBirthDay { get; set; }
        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        public Province SelectedProvince
        {
            get => Model.Province;
            set
            {
                if (value == null)
                    return;
                Model.Province = value;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get => Model.District;
            set
            {
                if (value == null)
                    return;
                Model.District = value;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard 
        {
            get => Model.Ward;
            set
            {
                Model.Ward = value;
                OnPropertyChanged(nameof(SelectedWard));
            }
        }

        public string StreetAddress
        {
            get => Model.address;
            set
            {
                Model.address = value;
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
