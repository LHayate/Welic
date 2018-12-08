using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Welic.App.Models.Search;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ICommand SearchCommand { get; private set; }

        public ObservableCollection<SearchDto> SearchFind { get; private set; }

        public string ISearch{get ;}

        public SearchViewModel()
        {
            ISearch = Util.ImagePorSistema("iFind");
            SearchCommand = new Command<string>(async (text) => await Search(text));
            SearchFind = new ObservableCollection<SearchDto>();
        }

        public async Task Search(string text)
        {
            try
            {
                SearchFind.Clear();
                IsBusy = false;                
                var searchResults = await (new SearchDto()).SearchClient(text);

                if (searchResults.Count > 0)
                {
                    foreach (SearchDto search in searchResults)
                    {
                        SearchFind.Add(new SearchDto {Image = search.Image, Name = search.Name, Description = search.Description, Location = search.Location});
                    }
                }
                else
                {
                    SearchFind.Clear();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                IsBusy = true;
                return;
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                IsBusy = true;
                return;
            }
        }
        public async Task ClearSearch()
        {
            SearchFind.Clear();
            IsBusy = false;
        }
    }
}
