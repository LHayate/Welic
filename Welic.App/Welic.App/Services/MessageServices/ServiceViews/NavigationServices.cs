using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Welic.App.Services.MessageServices.ServicesViewModels;
using Welic.App.ViewModels;
using Xamarin.Forms;

namespace Welic.App.Services.MessageServices.ServiceViews
{
    public class NavigationService : INavigationService
    {
        private readonly IMessageService _messageService;

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel)));
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            try
            {
                if (viewModelType.FullName != null)
                {
                    //var viewName1 = $"{viewModelType.Namespace.Replace("Model", string.Empty)}.{viewModelType.Name.Replace("ViewModel", string.Empty)}Page";
                    var viewName1 = $"{viewModelType.Namespace?.Replace("Model", string.Empty)}.{viewModelType.Name.Replace("ViewModel", string.Empty)}Page";
                    var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
                    var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName1, viewModelAssemblyName);
                    var viewType = Type.GetType(viewAssemblyName);
                    return viewType;
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowOkAsync("Erro ao tentar solicitar a pagina. " + ex.Message);
                return null;
            }
            return null;
        }

        private Page CreatePage(Type viewModelType)
        {
            try
            {
                Type pageType = GetPageTypeForViewModel(viewModelType);
                if (pageType == null)
                {
                    throw new Exception($"Não encontrado a pagina Solicitada {viewModelType}");
                }

                Page page = Activator.CreateInstance(pageType) as Page;
                return page;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
