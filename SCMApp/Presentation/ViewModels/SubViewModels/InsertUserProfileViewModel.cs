using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InsertUserProfileViewModel : ViewModelBase, IWindowViewBase
    {
        private readonly IUserWebAPI _userWebAPI;
        public InsertUserProfileViewModel(IUserWebAPI userWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _userWebAPI = userWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ProvinceList = Address.Instance().ProvinceList;
            Model = new UserProfile();
            IsCreate = true;
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
            get => Model.confirmPassword;
            set
            {
                Model.confirmPassword = value;
                OnPropertyChanged(nameof(VerifyPassword));
            }
        }
        public IList<string> UserRole => CommonConstants.UserRole;
        public string SelectedUserRole 
        {
            get => Model.role;
            set
            {
                Model.role = value;
                OnPropertyChangedNoInput();
            }
        }
        public DateTime? UserBirthDay 
        {
            get => Model.dateOfBirth == DateTime.MinValue ? null : Model.dateOfBirth;
            set
            {
                if (!value.HasValue)
                    return;
                Model.dateOfBirth = value.Value;
                OnPropertyChangedNoInput();
            }
        }

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        public Province SelectedProvince
        {
            get
            {
                var province = ProvinceList.SingleOrDefault(x => x.Id == Model.province);
                DistrictList = province?.Districts;
                return province;
            }
            set
            {
                if (value == null)
                    return;
                Model.province = value.Id;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get
            {
                if (SelectedProvince != null && DistrictList != null)
                {
                    var district = DistrictList.SingleOrDefault(x => x.Id == Model.district);
                    WardList = district?.Wards;
                    return district;
                }
                return null;
            }
            set
            {
                if (value == null)
                    return;
                Model.district = value.Id;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard
        {
            get
            {
                if (SelectedDistrict != null && WardList != null)
                {
                    return WardList.SingleOrDefault(x => x.Id == Model.ward);
                }
                return null;
            }
            set
            {
                if (value == null)
                    return;
                Model.ward = value.Id;
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

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {
            var newUser = new CreateUserDTO()
            {
                username = Model.username,
                fullName = Model.fullName,
                password = Model.password,
                confirmPassword = Model.confirmPassword,
                email = Model.email,
                role = Model.role,
                phoneNumber = Model.phoneNumber,
                dateOfBirth = Model.dateOfBirth,
                province = Model.province,
                district = Model.district,
                ward = Model.ward,
                address = Model.address,
            };
            using (new WaitCursorScope())
            {
                var r = _userWebAPI.CreateUser(newUser,Token);
            }
            View.Close();
        }
    }
}
