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
        public CustomerDetailViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            
            ProvinceList = Address.Instance().ProvinceList;
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        //private Customer Model;
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime? CustomerBirthDay { get; set; }
        public string TaxCode { get; set; }
        public List<string> Gender { get; set; }
        //public string Address { get; set; }
        public string Note { get; set; }

        //private readonly Address Address;

        public IList<Province> ProvinceList { get; set; }
        public IList<District> DistrictList { get; set; }
        public IList<Ward> WardList { get; set; }

        private Province _selectedProvince { get; set; }
        private District _selectedDistrict { get; set; }

        public Province SelectedProvince 
        {
            get => _selectedProvince;
            set
            {
                if (value == null)
                    return;
                _selectedProvince = value;
                WardList = null;
                OnPropertyChanged(nameof(WardList));
                DistrictList = value.Districts;
                OnPropertyChanged(nameof(DistrictList));
            }
        }
        public District SelectedDistrict
        {
            get => _selectedDistrict;
            set
            {
                if (value == null)
                    return;
                _selectedDistrict = value;
                WardList = value.Wards;
                OnPropertyChanged(nameof(WardList));
            }
        }
        public Ward SelectedWard { get; set; }
        

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
