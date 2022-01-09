using Newtonsoft.Json;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class CustomerDetailViewModel : ViewModelBase, IWindowViewBase
    {
        public CustomerDetailViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            
            ProvinceList = Address.Instance().ProvinceList;
            Gender = new List<string>() { "Nam", "Nữ" };
            Model = new Customer();
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        private Customer Model;
        public string CustomerName 
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        public string CustomerCode
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
                if(Model.dateOfBirth != DateTime.MinValue)
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
            get => Model.sex? "Nam" : "Nữ";
            set
            {
                Model.sex = value == "Nam"? true : false;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Note { get; set; }

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        public Province SelectedProvince
        {
            get => ProvinceList.SingleOrDefault(x => x.Id == Model.province);
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
                    return DistrictList.SingleOrDefault(x => x.Id == Model.district);
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

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
