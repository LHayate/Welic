﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter;
using Welic.App.Models.Course;
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
                IsBusy = true;                
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
                IsBusy = false;
                return;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                IsBusy = false;
                return;
            }
        }
        public async Task ClearSearch()
        {
            SearchFind.Clear();
            IsBusy = false;
        }

        public async Task<ObservableCollection<SearchDto>> SearchCursos(string text)
        {
            try
            {
                SearchFind.Clear();
                IsBusy = true;
                return await (new SearchDto()).SearchCursos(text);

                //if (searchResults.Count > 0)
                //{
                //    foreach (SearchDto search in searchResults)
                //    {
                //        SearchFind.Add(new SearchDto { Image = search.Image, Name = search.Name, Description = search.Description, Location = search.Location });
                //    }

                //    return SearchFind;
                //}

                //return null;                                    
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                IsBusy = false;
                return null;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                IsBusy = false;
                return null;
            }
        }
    }
}
