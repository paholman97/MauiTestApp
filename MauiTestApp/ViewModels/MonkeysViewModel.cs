using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models;
using MauiTestApp.Services;
using System.Collections.ObjectModel;

namespace MauiTestApp.ViewModels
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        MonkeyService monkeyService;

        public MonkeysViewModel(MonkeyService monkeyService)
        {
            this.monkeyService = monkeyService;
        }

        public ObservableCollection<Monkey> Monkeys { get; } = new();

        [RelayCommand] // Provides base implementation of ICommand interface
        async Task GetMonkeysAsync()
        {
            if (IsBusy) 
                return;

            try
            {
                IsBusy = true;

                var monkeys = await monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
