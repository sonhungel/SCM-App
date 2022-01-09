using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class HumanResourceManagementViewModelItem
    {
        public HumanResourceManagementViewModelItem(UserProfile user, Visibility isLoging)
        {
            Model = user;
            IsUserBeingLogin = isLoging;
        }
        public UserProfile Model { get; set; }
        public string UserName => Model.username;
        public string Name => Model.fullName;
        public string Email => Model.email;
        public string Title => Model.role;
        public string PhoneNumber => Model.phoneNumber;

        public Visibility IsUserBeingLogin;
    }
}
