using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class UserProfile: BusinessObjectBase
    {
        public UserProfile()
        {

        }
        public string username { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string VerifyPassword { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public string address { get; set; }
    }
}
