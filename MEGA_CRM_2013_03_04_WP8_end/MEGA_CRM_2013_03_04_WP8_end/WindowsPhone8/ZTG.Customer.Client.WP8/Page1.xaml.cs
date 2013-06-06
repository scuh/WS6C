using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using ZTG.Customer.Client.WP8.Resources;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;

namespace ZTG.Customer.Client.WP8
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            var saveAppBarButton = new ApplicationBarIconButton(new Uri("/Images/edittext.png", UriKind.Relative));
            saveAppBarButton.Text = AppResources.Update;
            saveAppBarButton.Click += EditButtonOnClick;
            ApplicationBar.Buttons.Add(saveAppBarButton);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var customerId = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("ID", out customerId))
            {
                App.CustomerUiService.SelectCustomer(Convert.ToInt32(customerId));
                DataContext = App.CustomerUiService.SelectedCustomer;
            }
            GeocodeQuery geoQuery = new GeocodeQuery();
            geoQuery.SearchTerm = App.CustomerUiService.SelectedCustomer.Country;
            geoQuery.GeoCoordinate = new GeoCoordinate(0, 0);
            geoQuery.QueryCompleted += setCountryPosition;
            geoQuery.QueryAsync();
        }

        private void EditButtonOnClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CustomerDetailPage.xaml?ID=" + App.CustomerUiService.SelectedCustomer.Id, UriKind.Relative));
        }

        /// <summary>
        /// Updates the binding of the current focused element.
        /// The changes in the current TextBox will not be saved if you do not call UpdateSource 
        /// </summary>
        private void UpdateFocusedElement()
        {
            var element = FocusManager.GetFocusedElement() as TextBox;
            if (element != null)
            {
                var binding = element.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }

        private void WebPage_Tap(object sender, GestureEventArgs e)
        {
            WebBrowserTask browserTask = new WebBrowserTask();
            browserTask.Uri = new Uri(App.CustomerUiService.SelectedCustomer.WebPage);
            browserTask.Show();
        }

        private void Phone_Tap(object sender, GestureEventArgs e)
        {
            showPhone(App.CustomerUiService.SelectedCustomer.PhoneNumber);
        }

        private void showPhone(string number)
        {
            PhoneCallTask phoneTask = new PhoneCallTask();
            phoneTask.PhoneNumber = number;
            phoneTask.DisplayName = App.CustomerUiService.SelectedCustomer.FirstName + App.CustomerUiService.SelectedCustomer.LastName;
            phoneTask.Show();
        }

        private void Mobile_Tap(object sender, GestureEventArgs e)
        {
            showPhone(App.CustomerUiService.SelectedCustomer.MobileNumber);
        }

        private void Mail_Tap(object sender, GestureEventArgs e)
        {
            EmailComposeTask mailTask = new EmailComposeTask();
            mailTask.To = App.CustomerUiService.SelectedCustomer.Email;
            mailTask.Show();
        }

        private void setCountryPosition(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            var r = e.Result;
            MapLocation loc = r.First();
            var test = loc.Information;
            var test2 = loc.BoundingBox;
            map.ZoomLevel = 6;
            map.Center = loc.GeoCoordinate;
        }
    }
}