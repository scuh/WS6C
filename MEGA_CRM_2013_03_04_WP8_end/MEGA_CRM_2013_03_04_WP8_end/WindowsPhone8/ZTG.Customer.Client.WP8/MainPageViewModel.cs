using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ZTG.Customer.Client.WP8.Helper;
using ZTG.Customer.Commons;

namespace ZTG.Customer.Client.WP8
{
    public class MainPageViewModel
    {
        private readonly CustomerUiService _customerUiService;

        public MainPageViewModel()
        {
            _customerUiService = App.CustomerUiService;
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return _customerUiService.Customers; }
        }

        public ObservableCollection<AlphaKeyGroup<CustomerViewModel>> CustomersGroup
        {
            get { return _customerUiService.CustomersGroup; }
        }
    }
}
