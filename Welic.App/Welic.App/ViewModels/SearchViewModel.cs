using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ICommand SearchCommand { get; private set; }
        
        public SearchViewModel()
        {
            SearchCommand = new Command<string>(async (text) => await Search(text));
                        
        }

        public async Task Search(string text)
        {            
           
        }
    }
}
