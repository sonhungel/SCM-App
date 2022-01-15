using SCMApp.Event_Delegate;
using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class PartnerDetailViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IPartnerWebAPI _partnerWebAPI;
        public PartnerDetailViewModel(IPartnerWebAPI partnerWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _partnerWebAPI = partnerWebAPI;
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
            PartnerType = new List<string>() { "Doanh nghiệp", "Cá nhân" };
            Model = new Partner();
            IsCreate = true;
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
        public int? PartnerCode
        {
            get => Model.supplierNumber;
            set
            {
                Model.supplierNumber = value;
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
        public string SelectedPartnerType 
        {
            get => Model.type ? "Doanh nghiệp" : "Cá nhân";
            set
            {
                Model.type = value == "Doanh nghiệp" ? true : false;
                OnPropertyChanged(nameof(SelectedPartnerType));
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

        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(PartnerFullName));
            CleanUpError(nameof(PartnerPhoneNumber));
            CleanUpError(nameof(PartnerEmail));
            CleanUpError(nameof(PartnerType));
            CleanUpError(nameof(SelectedProvince));
            CleanUpError(nameof(SelectedDistrict));
            CleanUpError(nameof(SelectedWard));
            CleanUpError(nameof(StreetAddress));

            if (string.IsNullOrEmpty(PartnerFullName))
            {
                AddError(nameof(PartnerFullName), "Tên nhà cung cấp không hợp lệ.");
            }
            if (string.IsNullOrEmpty(PartnerPhoneNumber) || PartnerPhoneNumber.Count() <= 9)
            {
                AddError(nameof(PartnerPhoneNumber), "Số điện thoại không hợp lệ.");
            }
            if (string.IsNullOrEmpty(PartnerEmail) || !ValidatorExtensions.IsValidEmailAddress(PartnerEmail))
            {
                AddError(nameof(PartnerEmail), "Email không hợp lệ.");
            }
            if (string.IsNullOrEmpty(SelectedPartnerType))
            {
                AddError(nameof(SelectedPartnerType), "Giới tính không được trống.");
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
                    var createSupplier = new CreateSupplierDTO()
                    {
                        supplierNumber = Model.supplierNumber == 0 ? null : Model.supplierNumber,
                        name = Model.name,
                        phoneNumber = Model.phoneNumber,
                        email = Model.email,
                        type = Model.type ? 1 : 0,
                        province = Model.province,
                        district = Model.district,
                        ward = Model.ward,
                        address = Model.address,
                        taxNumber = Model.taxNumber,
                        remark = Model.remark,
                    };
                    var r = _partnerWebAPI.CreateSupplier(createSupplier, Token);
                }
            }
            else
            {
                using (new WaitCursorScope())
                {
                    var updateSupplier = new UpdateSupplierDTO()
                    {
                        id = Model.id,
                        name = Model.name,
                        phoneNumber = Model.phoneNumber,
                        email = Model.email,
                        province = Model.province,
                        district = Model.district,
                        ward = Model.ward,
                        address = Model.address,
                        taxNumber = Model.taxNumber,
                        remark = Model.remark,
                        version = Model.version
                    };
                    var result = _partnerWebAPI.UpdateSupplier(updateSupplier, Token);
                    ReloadAfterCloseSubView.Instance.Invoke(result);
                }
            }    
            View.Close();
        }
    }
}
