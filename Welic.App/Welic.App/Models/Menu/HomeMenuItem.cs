using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Galery,
        Notifications,
        Videos,
        Settings,
        SignUp,
        Tickets


    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }
    }
}
