using System.ComponentModel;
using System.Runtime.CompilerServices;
using ZTG.Customer.Client.WP8.Annotations;

namespace ZTG.Customer.Client.WP8.Helper
{
    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
