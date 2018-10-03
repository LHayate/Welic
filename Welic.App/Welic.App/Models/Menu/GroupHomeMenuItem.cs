using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Welic.App.Models.Menu
{
    public class GroupHomeMenuItem: ObservableCollection<HomeMenuItem>, INotifyPropertyChanged
    {
        private bool _expanded;

        public MenuItemType Id { get; set; }

        public string _iconMenu;
        private string IconMenu
        {
            get => _iconMenu;
            set => _iconMenu = value;
        }
        public string Title { get; set; }
        public int MenuCount { get; set; }

        public GroupHomeMenuItem(string title, string shortName, bool expanded = true)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        public GroupHomeMenuItem()
        {
            
        }
        
        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, MenuCount); }
        }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("IconMenu");
                }
            }
        }               

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
