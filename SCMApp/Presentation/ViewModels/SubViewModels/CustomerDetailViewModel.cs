using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class CustomerDetailViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly ICustomerWebAPI _customerWebAPI;
        public CustomerDetailViewModel(ICustomerWebAPI customerWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _customerWebAPI = customerWebAPI;
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
            Gender = new List<string>() { "Nam", "Nữ" };
            Model = new Customer();
            IsCreate = true;
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public Customer Model;

        public string CustomerName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        public int? CustomerCode
        {
            get => Model.customerNumber;
            set
            {
                Model.customerNumber = value;
                OnPropertyChanged(nameof(CustomerCode));
            }
        }

        public string CustomerPhoneNumber
        {
            get => Model.phoneNumber;
            set
            {
                Model.phoneNumber = value;
                OnPropertyChanged(nameof(CustomerPhoneNumber));
            }
        }
        public string CustomerEmail
        {
            get => Model.email;
            set
            {
                Model.email = value;
                OnPropertyChanged(nameof(CustomerEmail));
            }
        }
        public DateTime? CustomerBirthDay
        {
            get
            {
                if (Model.dateOfBirth != DateTime.MinValue)
                    return Model.dateOfBirth;
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    Model.dateOfBirth = value.Value;
                    OnPropertyChanged(nameof(CustomerBirthDay));
                }
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

        public List<string> Gender { get; set; }
        public string SelectedGender
        {
            get => Model.sex ? "Nam" : "Nữ";
            set
            {
                Model.sex = value == "Nam" ? true : false;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
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

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(CustomerName));
            CleanUpError(nameof(CustomerPhoneNumber));
            CleanUpError(nameof(CustomerEmail));
            CleanUpError(nameof(CustomerBirthDay));
            CleanUpError(nameof(SelectedGender));
            CleanUpError(nameof(SelectedProvince));
            CleanUpError(nameof(SelectedDistrict));
            CleanUpError(nameof(SelectedWard));
            CleanUpError(nameof(StreetAddress));
            CleanUpError(nameof(TaxCode)); 

            if (string.IsNullOrEmpty(CustomerName))
            {
                AddError(nameof(CustomerName), "Tên khách hàng không được trống.");
            }
            if (string.IsNullOrEmpty(CustomerPhoneNumber) || CustomerPhoneNumber.Count() <= 9)
            {
                AddError(nameof(CustomerPhoneNumber), "Số điện thoại không được trống.");
            }
            if (string.IsNullOrEmpty(CustomerEmail) || !ValidatorExtensions.IsValidEmailAddress(CustomerEmail))
            {
                AddError(nameof(CustomerEmail), "Email không hợp lệ.");
            }
            if (!CustomerBirthDay.HasValue)
            {
                AddError(nameof(CustomerBirthDay), "Ngày sinh không được trống");

            }
            else if (CustomerBirthDay.Value < new DateTime(1753, 1, 1))
            {
                AddError(nameof(CustomerBirthDay), "Ngày sinh không hợp lệ.");
            }
            if (string.IsNullOrEmpty(SelectedGender))
            {
                AddError(nameof(SelectedGender), "Giới tính không được trống.");
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
            if (string.IsNullOrEmpty(TaxCode))
            {
                AddError(nameof(TaxCode), "Mã số thuế không được trống.");
            }
        }

        public bool IsCreate { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {
            if (IsCreate)
            {
                using (new WaitCursorScope())
                {
                    var createCustomer = new CreateCustomerDTO()
                    {
                        customerNumber = Model.customerNumber == 0? null : Model.customerNumber,
                        name = Model.name,
                        phoneNumber = Model.phoneNumber,
                        email = Model.email,
                        dateOfBirth = Model.dateOfBirth,
                        sex = Model.sex ? 1 : 0,
                        province = Model.province,
                        district = Model.district,
                        ward = Model.ward,
                        address = Model.address,
                        taxNumber = Model.taxNumber,
                        remark = Model.remark,
                    };
                    var r = _customerWebAPI.CreateCustomer(createCustomer, Token);
                }
            }
            else
            {
                using (new WaitCursorScope())
                {
                    var updateCustomer = new UpdateCustomerDTO()
                    {
                        id = Model.id,
                        name = Model.name,
                        phoneNumber = Model.phoneNumber,
                        email = Model.email,
                        dateOfBirth = Model.dateOfBirth,
                        sex = Model.sex ? 1 : 0,
                        province = Model.province,
                        district = Model.district,
                        ward = Model.ward,
                        address = Model.address,
                        taxNumber = Model.taxNumber,
                        remark = Model.remark,
                        version = Model.version
                    };
                    var r = _customerWebAPI.UpdateCustomer(updateCustomer, Token);
                }
            }    
            View.Close();
        }
    }
}
