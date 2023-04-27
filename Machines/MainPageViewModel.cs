using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Helpers;
using System.Windows.Input;

namespace MauiApp1
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string title1;
        [ObservableProperty]
        private string title2;

        [ObservableProperty]
        private ImageSource imageMaui;

        [ObservableProperty]
        bool isRefreshing;


        public ICommand RefreshCommand => new AsyncCommand(() => LoadServiceAsync());


        public MainPageViewModel() 
        {
            RefreshCommand.Execute(null);
        }

        private async Task LoadServiceAsync()
        {
            Title1 = "Hello, World! : ";
            Title2 = "Welcome to .NET Multi-platform App UI";
            ImageMaui = ImageSource.FromFile("dotnet_bot.png");
            IsRefreshing = false;
        }
    }
}
