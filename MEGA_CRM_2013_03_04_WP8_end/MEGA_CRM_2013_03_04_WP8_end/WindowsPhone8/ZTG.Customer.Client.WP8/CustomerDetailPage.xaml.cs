using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ZTG.Customer.Client.WP8.Resources;

namespace ZTG.Customer.Client.WP8
{
    public partial class CustomerDetailPage : PhoneApplicationPage
    {
        public CustomerDetailPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            var saveAppBarButton = new ApplicationBarIconButton(new Uri("/Images/save.png", UriKind.Relative));
            saveAppBarButton.Text = AppResources.Save;
            saveAppBarButton.Click += SaveButtonOnClick;
            ApplicationBar.Buttons.Add(saveAppBarButton);

            var deleteAppBarButton = new ApplicationBarIconButton(new Uri("/Images/delete.png", UriKind.Relative));
            deleteAppBarButton.Text = AppResources.Delete;
            deleteAppBarButton.Click += DeleteButtonOnClick;
            ApplicationBar.Buttons.Add(deleteAppBarButton);
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
        }

        private void SaveButtonOnClick(object sender, EventArgs e)
        {
            UpdateFocusedElement();
            App.CustomerUiService.SaveSelectedCustomer(Navigate);
        }

        private void DeleteButtonOnClick(object sender, EventArgs e)
        {
            UpdateFocusedElement();
            App.CustomerUiService.DeleteSelectedCustomer(Navigate);
        }

        private void Navigate()
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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
    }
}