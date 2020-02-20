using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUserInterface.Utilities
{
    public class NotifyProperty<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private T value;
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}