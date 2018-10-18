using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using CommonServiceLocator;
using Welic.App.Services.ServicesViewModels;
using Welic.App.Services.ServiceViews;
using Unity;
using Unity.ServiceLocation;
using Welic.App.Services.Navigation;
using Welic.App.Services.Timing;
using Xamarin.Forms;

namespace Welic.App.ViewModels.Base
{
    class ViewModelLocator
    {
        private static UnityContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            _container = new UnityContainer();
            
            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            _container.RegisterType<AboutViewModel>();
            _container.RegisterType<HomeViewModel>();
            _container.RegisterType<InicioViewModel>();
            _container.RegisterType<LoginViewModel>();
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<LoginExternoViewModel>();
            _container.RegisterType<MenuViewModel>();
            _container.RegisterType<SearchViewModel>();
            _container.RegisterType<ListLiveViewModel>();
            _container.RegisterType<ListEventsViewModel>();
            _container.RegisterType<ListNewsViewModel>();
            _container.RegisterType<LiveViewModel>();
            

            // Services - by default, TinyIoC will register interface registrations as singletons.

            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IMessageService, MessageServices>();                        
            _container.RegisterType<IOpenUrlService, OpenUrlService>();
            _container.RegisterType<IIdentityService, IdentityService>();
            _container.RegisterType<IRequestProvider, RequestProvider>();
            _container.RegisterType<IDependencyService, Welic.App.Services.ServiceViews.DependencyService>();
            _container.RegisterType<ISettingsService, SettingsService>();            
            _container.RegisterType<ILocationService, LocationService>();
            _container.RegisterType<ITiming, Timing>();

            var unityServiceLocator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider((() => unityServiceLocator));
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                UseMockService = true;
            }
            else
            {                
                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.RegisterSingleton<TInterface, T>();
        }

        public static T Resolve<T>() where T : class
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }            
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
