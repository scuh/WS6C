using System;
using System.IO;
using System.Windows.Media.Imaging;
using ZTG.Customer.Client.WP8.Helper;

namespace ZTG.Customer.Client.WP8
{
    public class CustomerViewModel : NotificationObject
    {
        private readonly Model.Customer _customer;

        public CustomerViewModel(Model.Customer customer)
        {
            _customer = customer;
            var bitmapImage = new BitmapImage();
            if (_customer.Image != null)
            {
                var stream = new MemoryStream(_customer.Image);
                bitmapImage.SetSource(stream);
            }
            BitmapImage = bitmapImage;
        }

        public Model.Customer Customer
        {
            get { return _customer; }
        }

        public string Name
        {
            get { return _customer.FirstName + " " + _customer.MiddleName + " " + _customer.LastName; }
        }

        public BitmapImage BitmapImage { get; set; }

        public int Id
        {
            get { return _customer.Id; }
            set
            {
                _customer.Id = value;
                Notify();
            }
        }

        public string Title
        {
            get { return _customer.Title; }
            set
            {
                _customer.Title = value;
                Notify();
            }
        }
        public string FirstName
        {
            get { return _customer.FirstName; }
            set
            {
                _customer.FirstName = value;
                Notify();
            }
        }
        public string MiddleName
        {
            get { return _customer.MiddleName; }
            set
            {
                _customer.MiddleName = value;
                Notify();
            }
        }
        public string LastName
        {
            get { return _customer.LastName; }
            set
            {
                _customer.LastName = value;
                Notify();
            }
        }
        public string Company
        {
            get { return _customer.Company; }
            set
            {
                _customer.Company = value;
                Notify();
            }
        }
        public string WebPage
        {
            get { return _customer.WebPage; }
            set
            {
                _customer.WebPage = value;
                Notify();
            }
        }
        public string PhoneNumber
        {
            get { return _customer.PhoneNumber; }
            set
            {
                _customer.PhoneNumber = value;
                Notify();
            }
        }
        public string FaxNumber
        {
            get { return _customer.FaxNumber; }
            set
            {
                _customer.FaxNumber = value;
                Notify();
            }
        }
        public string MobileNumber
        {
            get { return _customer.MobileNumber; }
            set
            {
                _customer.MobileNumber = value;
                Notify();
            }
        }
        public string Street
        {
            get { return _customer.Street; }
            set
            {
                _customer.Street = value;
                Notify();
            }
        }
        public string Email
        {
            get { return _customer.Email; }
            set
            {
                _customer.Email = value;
                Notify();
            }
        }
        public string City
        {
            get { return _customer.City; }
            set
            {
                _customer.City = value;
                Notify();
            }
        }
        public string State
        {
            get { return _customer.State; }
            set
            {
                _customer.State = value;
                Notify();
            }
        }
        public string PostalCode
        {
            get { return _customer.PostalCode; }
            set
            {
                _customer.PostalCode = value;
                Notify();
            }
        }
        public string Country
        {
            get { return _customer.Country; }
            set
            {
                _customer.Country = value;
                Notify();
            }
        }
        public string Department
        {
            get { return _customer.Department; }
            set
            {
                _customer.Department = value;
                Notify();
            }
        }
        public string Office
        {
            get { return _customer.Office; }
            set
            {
                _customer.Office = value;
                Notify();
            }
        }
        public string Profession
        {
            get { return _customer.Profession; }
            set
            {
                _customer.Profession = value;
                Notify();
            }
        }
        public string ManagersName
        {
            get { return _customer.ManagersName; }
            set
            {
                _customer.ManagersName = value;
                Notify();
            }
        }
        public string AssistantName
        {
            get { return _customer.AssistantName; }
            set
            {
                _customer.AssistantName = value;
                Notify();
            }
        }
        public string Nickname
        {
            get { return _customer.Nickname; }
            set
            {
                _customer.Nickname = value;
                Notify();
            }
        }
        public String Birthday
        {
            get { return _customer.Birthday.ToShortDateString(); }
            set
            {
                _customer.Birthday = DateTime.Parse(value);
                Notify();
            }
        }
        public byte[] Image
        {
            get { return _customer.Image; }
            set
            {
                _customer.Image = value;
                Notify();
            }
        }
        public int Sales
        {
            get { return _customer.Sales; }
            set
            {
                _customer.Sales = value;
                Notify();
            }
        }
        public int Margin
        {
            get { return _customer.Margin; }
            set
            {
                _customer.Margin = value;
                Notify();
            }
        }
    }
}
