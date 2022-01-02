using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public Province ProvinceAddress { get; set; }
        public District DistrictAddress { get; set; }
        public Ward WardAddress { get; set; }
        public string StreetAddress { get; set; }
    }
}
