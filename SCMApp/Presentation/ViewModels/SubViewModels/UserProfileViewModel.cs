using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class UserProfileViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IUserWebAPI _userWebAPI;
        public UserProfileViewModel(IUserWebAPI userWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _userWebAPI = userWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p =>
            {
                ValidateAllProperty();
                if (!HasErrors)
                {
                    SaveAction();
                }
            });

            ProvinceList = Address.Instance().ProvinceList;
            IsCreate = true;
            IsUpdateByHRM = false;
            RoleList = new List<string>()
            {
                "Quản lý","Nhân viên"
            };
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public bool IsUpdateByHRM { get; set; }
        public Visibility IsVisibleByHRM => IsUpdateByHRM ? Visibility.Hidden : Visibility.Visible;

        private UpdateUserDTO _updateModel { get; set; }
        private UserProfile _model;
        public UserProfile Model
        {
            get => _model;
            set
            {
                _model = value;
                if (_updateModel == null)
                {
                    _updateModel = new UpdateUserDTO()
                    {
                        fullName = _model.fullName,
                        username = _model.username,
                        email = _model.email,
                        role = _model.role,
                        phoneNumber = _model.phoneNumber,
                        dateOfBirth = _model.dateOfBirth,
                        province = _model.province,
                        district = _model.district,
                        ward = _model.ward,
                        address = _model.address,
                        version = _model.version,
                    };
                }
            }
        }

        public bool IsManager => Model.role == "Quản lý" ? true : false;

        public string UserFullName
        {
            get => _updateModel.fullName;
            set
            {
                _updateModel.fullName = value;
                OnPropertyChanged(nameof(UserFullName));
            }
        }
        public string UserName
        {
            get => _updateModel.username;
            set
            {
                _updateModel.username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string UserEmail
        {
            get => _updateModel.email;
            set
            {
                _updateModel.email = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }
        public string UserPhoneNumber
        {
            get => _updateModel.phoneNumber;
            set
            {
                _updateModel.phoneNumber = value;
                OnPropertyChanged(nameof(UserPhoneNumber));
            }
        }

        public string CurrentPassWord
        {
            get => _updateModel.oldPassword;
            set
            {
                if (!IsUpdateByHRM)
                {
                    _updateModel.oldPassword = value;
                    if (string.IsNullOrEmpty(value))
                    {
                        _updateModel.oldPassword = null;
                    }
                }
                
                _updateModel.oldPassword = value;
                if (string.IsNullOrEmpty(value))
                {
                    _updateModel.oldPassword = null;
                }
                OnPropertyChanged(nameof(CurrentPassWord));
            }
        }
        public string NewPassword
        {
            get => _updateModel.password;
            set
            {
                _updateModel.password = value;
                if (string.IsNullOrEmpty(value))
                {
                    _updateModel.password = null;
                }
                OnPropertyChanged(nameof(NewPassword));
            }
        }
        private string _verifyPassword;
        public string VerifyPassword
        {
            get => _verifyPassword;
            set
            {
                _verifyPassword = value;
                OnPropertyChanged(nameof(VerifyPassword));
            }
        }
        public DateTime? UserBirthDay
        {
            get => _updateModel.dateOfBirth;
            set
            {
                if (!value.HasValue)
                    return;
                _updateModel.dateOfBirth = value.Value;
                OnPropertyChangedNoInput();
            }
        }
        public IList<string> RoleList { get; set; }
        public string SelectedUserRole
        {
            get => _updateModel.role;
            set
            {
                _updateModel.role = value;
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
                var province = ProvinceList.SingleOrDefault(x => x.Id == _updateModel.province);
                DistrictList = province?.Districts;
                return province;
            }
            set
            {
                if (value == null)
                    return;
                _updateModel.province = value.Id;
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
                    var district = DistrictList.SingleOrDefault(x => x.Id == _updateModel.district);
                    WardList = district?.Wards;
                    return district;
                }
                return null;
            }
            set
            {
                if (value == null)
                    return;
                _updateModel.district = value.Id;
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
                    return WardList.SingleOrDefault(x => x.Id == _updateModel.ward);
                }
                return null;
            }
            set
            {
                if (value == null)
                    return;
                _updateModel.ward = value.Id;
                OnPropertyChanged(nameof(SelectedWard));
            }
        }

        public string StreetAddress
        {
            get => _updateModel.address;
            set
            {
                _updateModel.address = value;
                OnPropertyChanged(nameof(StreetAddress));
            }
        }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(UserFullName));
            CleanUpError(nameof(UserName));
            CleanUpError(nameof(UserEmail));
            CleanUpError(nameof(UserPhoneNumber));
            CleanUpError(nameof(UserBirthDay));
            CleanUpError(nameof(SelectedUserRole));

            CleanUpError(nameof(CurrentPassWord));
            CleanUpError(nameof(NewPassword));
            CleanUpError(nameof(VerifyPassword));

            CleanUpError(nameof(SelectedProvince));
            CleanUpError(nameof(SelectedDistrict));
            CleanUpError(nameof(SelectedWard));
            CleanUpError(nameof(StreetAddress));

            if (string.IsNullOrEmpty(UserFullName))
            {
                AddError(nameof(UserFullName), "Họ và tên không được trống.");
            }
            if (string.IsNullOrEmpty(UserName))
            {
                AddError(nameof(UserName), "Tên đăng nhập không được trống.");
            }
            if (string.IsNullOrEmpty(UserEmail) || !ValidatorExtensions.IsValidEmailAddress(UserEmail))
            {
                AddError(nameof(UserEmail), "Email không hợp lệ.");
            }
            if (string.IsNullOrEmpty(UserPhoneNumber) || UserPhoneNumber.Count() <= 9)
            {
                AddError(nameof(UserPhoneNumber), "Số điện thoại không hợp lệ.");
            }
            if (!UserBirthDay.HasValue)
            {
                AddError(nameof(UserBirthDay), "Ngày sinh không được trống");

            }
            else if (UserBirthDay.Value < new DateTime(1753, 1, 1))
            {
                AddError(nameof(UserBirthDay), "Ngày sinh không hợp lệ.");
            }

            if (IsUpdateByHRM)
            {
                if (string.IsNullOrEmpty(VerifyPassword) && !string.IsNullOrEmpty(NewPassword))
                {
                    AddError(nameof(VerifyPassword), "Xác nhận mật khẩu không được trống.");
                }

                if (!string.IsNullOrEmpty(VerifyPassword) && !string.IsNullOrEmpty(NewPassword) && NewPassword != VerifyPassword)
                {
                    AddError(nameof(VerifyPassword), "Mật khẩu và xác nhận mật khẩu không khớp.");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(CurrentPassWord) && string.IsNullOrEmpty(NewPassword))
                {
                    AddError(nameof(NewPassword), "Mật khẩu mới không được trống nếu đổi.");
                }
                if (!string.IsNullOrEmpty(CurrentPassWord) && string.IsNullOrEmpty(VerifyPassword))
                {
                    AddError(nameof(VerifyPassword), "Xác nhận mật khẩu mới không được trống nếu đổi.");
                }
                if (!string.IsNullOrEmpty(CurrentPassWord) && !string.IsNullOrEmpty(CurrentPassWord) && CurrentPassWord.Count() <= 5)
                {
                    AddError(nameof(CurrentPassWord), "Mật khẩu phải đủ 6 ký tự.");
                }
                if (!string.IsNullOrEmpty(VerifyPassword) && !string.IsNullOrEmpty(NewPassword) && NewPassword != VerifyPassword)
                {
                    AddError(nameof(VerifyPassword), "Mật khẩu và xác nhận mật khẩu không khớp.");
                }

                if ((!string.IsNullOrEmpty(VerifyPassword) || !string.IsNullOrEmpty(NewPassword)) && string.IsNullOrEmpty(CurrentPassWord))
                {
                    AddError(nameof(CurrentPassWord), "Hãy nhập mật khẩu hiện tại nếu muốn đổi.");
                }
            }
            if (string.IsNullOrEmpty(SelectedUserRole))
            {
                AddError(nameof(SelectedUserRole), "Chức vụ không được trống.");
            }
            if (SelectedProvince == null)
            {
                AddError(nameof(SelectedProvince), "Tỉnh/TP không được trống.");
            }
            if (SelectedDistrict == null)
            {
                AddError(nameof(SelectedDistrict), "Quận/Huyện không được trống.");
            }

            if (SelectedWard == null)
            {
                AddError(nameof(SelectedWard), "Phường/Xã không được trống.");
            }

            if (string.IsNullOrEmpty(StreetAddress))
            {
                AddError(nameof(StreetAddress), "Địa chỉ không được trống.");
            }
        }

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

            using (new WaitCursorScope())
            {
                if (IsUpdateByHRM)
                {
                    var updateUserByManager = new UpdateUserByManagerDTO()
                    {
                        fullName = _model.fullName,
                        username = _model.username,
                        email = _model.email,
                        role = _model.role,
                        password = NewPassword,
                        phoneNumber = _model.phoneNumber,
                        dateOfBirth = _model.dateOfBirth,
                        province = _model.province,
                        district = _model.district,
                        ward = _model.ward,
                        address = _model.address,
                        version = _model.version,
                    };
                    var r = _userWebAPI.UpdateUserByManager(updateUserByManager, Token);
                }
                else
                {
                    var r = _userWebAPI.UpdateUser(_updateModel, Token);
                }    
            }

            View.Close();
        }
    }
}
