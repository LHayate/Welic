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
        Tickets,
        SignOff,
        NewLive,
        Cursos,
        EBooks,
        Schedule



    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }
    }
}
