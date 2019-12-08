using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InsuranceApi.Models
{
    enum UserTypes
    {
        user,
        admin
    }

    public class Client
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string Token { get; set; }
    }
}