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
        public string UserName => Model.UserName;
        public string Name => Model.Name;
        public string Email => Model.Email;
        public string Title => Model.Title;
        public string PhoneNumber => Model.PhoneNumber;

        public ICommand DeleteUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
    }
}
