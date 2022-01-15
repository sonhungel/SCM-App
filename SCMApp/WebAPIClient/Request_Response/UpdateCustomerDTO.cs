﻿
using System;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class UpdateCustomerDTO
    {
        public int id { get; set; }
        public int version { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string taxNumber { get; set; }
        public int sex { get; set; }
        public string address { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public string remark { get; set; }
    }
}
