using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiTestApp.ViewModels
{
    // ObservableObject - Implements INotifyPropertyChanged and attributes to expose props without manually coding
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(IsNotBusy))] //Also notifies IsNotBusy when value changes
        bool isBusy; // Lets view know if view model is busy to prevent duplicate operations e.g. refreshing data

        public bool IsNotBusy => !IsBusy;
    }
}
