using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.Helpers
{
    public partial class BaseViewModel : ObservableObject, INotifyPropertyChanged
    {

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(IsNotBusy))]
        //public bool isBusy;
        //public bool IsNotBusy => !IsBusy;


        public virtual Task InitializeAsync() => Task.CompletedTask;
        public virtual Task UninitializeAsync() => Task.CompletedTask;


        protected bool SetAndRaisePropertyChanged<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


    }
}
