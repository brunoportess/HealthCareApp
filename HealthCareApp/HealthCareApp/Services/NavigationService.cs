﻿using HealthCareApp.ViewModels;
using HealthCareApp.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HealthCareApp.Services
{
    public class NavigationService
    {
        static readonly Lazy<NavigationService> navigation =
            new Lazy<NavigationService>(() => new NavigationService());

        public static NavigationService Current => navigation.Value;

        Shell Shell => Shell.Current;

        Page CurrentPage { get; set; }

        NavigationService()
        {
            RegisterRoutes();
            Shell.Navigated += OnShellNavigated;
            Shell.Navigating += OnShellNavigating;
        }

        // não funciona com métodos assíncronos 
        void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            var current = e.Current;
            /*if (current.Location.OriginalString.Contains("MainViewModel"))
            {
                var vm = CurrentPage.BindingContext as MainViewModel;
                if (!vm.IsChecked)
                    e.Cancel();
            }*/
        }

        void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
        {
            var page = Shell.CurrentItem.CurrentItem as ShellSection;
            CurrentPage = ((IShellSectionController)page).PresentedPage;
            Preferences.Set("LastKnownUrl", e.Current.Location.OriginalString);
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(LoginViewModel), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterViewModel), typeof(RegisterPage));
        }

        public async Task GoToAsync(string url, object args = null)
        {
            await Shell.GoToAsync(url);
            if (url == ".." || url.Contains("\\") || url.Contains("/"))
            {
                await (CurrentPage.BindingContext as BaseViewModel).BackAsync(args);
                return;
            }
            var vm = CreateViewModel(url);
            CurrentPage.BindingContext = vm;
            await vm.InitAsync(args).ConfigureAwait(false);
        }

        public async Task GoToRootAsync()
        {
            await Shell.Navigation.PopToRootAsync();
        }

        public async Task GoToAsync(ShellNavigationState state, object args = null)
        {
            await Shell.GoToAsync(state);
            var vm = CreateViewModel(state.Location.OriginalString.Split('/').Last());
            await Task.Delay(100); // aguardar a pagina carregar
            CurrentPage.BindingContext = vm;
            await vm.InitAsync(args).ConfigureAwait(false);
        }

        BaseViewModel CreateViewModel(string url)
        {
            var name = typeof(NavigationService).AssemblyQualifiedName.Split('.')[0];
            var typeName = $"{name}.ViewModels.{url}";
            var viewModel = (BaseViewModel)Activator.CreateInstance(Type.GetType(typeName));
            return viewModel;
        }
    }
}
