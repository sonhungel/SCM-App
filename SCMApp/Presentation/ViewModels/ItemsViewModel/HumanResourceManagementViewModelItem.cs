using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class HumanResourceManagementViewModelItem
    {
        public HumanResourceManagementViewModelItem(UserProfile user)
        {
            Model = user;
        }
        public UserProfile Model { get; set; }
        public string UserName => Model.username;
        public string Name => Model.fullName;
        public string Email => Model.email;
        public string Title => Model.Title;
        public string PhoneNumber => Model.phoneNumber;

    }
}
