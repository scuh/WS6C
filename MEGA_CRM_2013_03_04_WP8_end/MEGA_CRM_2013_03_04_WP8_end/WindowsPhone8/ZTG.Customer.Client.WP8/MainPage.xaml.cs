using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ZTG.Customer.Client.WP8.Resources;

namespace ZTG.Customer.Client.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            ViewModel = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel
        {
            get { return DataContext as MainPageViewModel; }
            set { DataContext = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.CustomerUiService.LoadCustomers();

        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            var addAppBarButton = new ApplicationBarIconButton(new Uri("/Images/add.png", UriKind.Relative));
            addAppBarButton.Text = AppResources.Add;
            addAppBarButton.Click += AddButtonOnClick;
            ApplicationBar.Buttons.Add(addAppBarButton);

            var updateAppBarButton = new ApplicationBarIconButton(new Uri("/Images/refresh.png", UriKind.Relative));
            updateAppBarButton.Text = AppResources.Update;
            updateAppBarButton.Click += RefreshButtonOnClick;
            ApplicationBar.Buttons.Add(updateAppBarButton);
        }

        private void _customerList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_customerList.SelectedItem != null)
            {
                var customerViewModel = (_customerList.SelectedItem as CustomerViewModel);
                NavigationService.Navigate(new Uri("/Page1.xaml?ID=" + customerViewModel.Id, UriKind.Relative));
            }
        }

        private void AddButtonOnClick(object sender, EventArgs e)
        {
            var id = App.CustomerUiService.NewCustomer();
            NavigationService.Navigate(new Uri("/CustomerDetailPage.xaml?ID=" + id, UriKind.Relative));
        }

        private void RefreshButtonOnClick(object sender, EventArgs e)
        {
            App.CustomerUiService.LoadCustomers();
        }
    }
}