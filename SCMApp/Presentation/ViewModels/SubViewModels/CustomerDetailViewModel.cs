using Newtonsoft.Json;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.IO;
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
            get => Model.CustomerName;
            set
            {
                Model.CustomerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        public string CustomerCode
        {
            get => Model.CustomerCode;
            set
            {
                Model.CustomerCode = value;
                OnPropertyChanged(nameof(CustomerCode));
            }
        }

        public string CustomerPhoneNumber
        {
            get => Model.CustomerPhoneNumber;
            set
            {
                Model.CustomerPhoneNumber = value;
                OnPropertyChanged(nameof(CustomerPhoneNumber));
            }
        }
        public string CustomerEmail
        {
            get => Model.CustomerEmail;
            set
            {
                Model.CustomerEmail = value;
                OnPropertyChanged(nameof(CustomerEmail));
            }
        }
        public DateTime? CustomerBirthDay
        {
            get 
            {
                if(Model.CustomerBirthDay != DateTime.MinValue)
                    return Model.CustomerBirthDay;
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    Model.CustomerBirthDay = value.Value;
                    OnPropertyChanged(nameof(CustomerBirthDay));
                }
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

        public List<string> Gender { get; set; }
        public string SelectedGender 
        {
            get => Model.Gender;
            set
            {
                Model.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Note { get; set; }

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
