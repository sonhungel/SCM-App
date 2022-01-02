using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models.DTOObject
{
    public class LoginInfo
    {
        public LoginInfo(string email,string pass)
        {
            username = email;
            password = pass;
        }
        public string username { get; set; }
        public string password { get; set; }
    }
}
