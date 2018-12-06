using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        public ConfigViewModel()
        {
            
        }

        private bool _isOwned;
        public bool IsOwned
        {
            get => _isOwned;
            set => _isOwned = value;
        }
    }
}
