using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class UserProfile
    {
        public string UserName => "Sonhunge";
        public string Password => "123455";
        public string Email => "sonhungel@gmail.com";
        public string Name => "Trần Sơn";
        public string Title => "Chủ cửa hàng";
        public string PhoneNumber => "0964303424";
        public DateTime BirthDay => DateTime.Now;
        public string ProvinceAddress { get; set; }
        public string DistrictAddress { get; set; }
        public string WardAddress { get; set; }
        public string StreetAddress { get; set; }
    }
}
