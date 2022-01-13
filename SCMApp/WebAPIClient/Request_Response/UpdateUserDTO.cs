﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class UpdateUserDTO
    {
        public string username { get; set; }
        public string fullName { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
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
