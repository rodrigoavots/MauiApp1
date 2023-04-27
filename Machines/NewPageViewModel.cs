using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Database;
using MauiApp1.Helpers;
using MauiApp1.Repositorio;
using System.Windows.Input;

namespace MauiApp1.Machines
{
    public partial class NewPageViewModel : BaseViewModel
    {
        ImagesRepositorio rep;
        int ind;

        [ObservableProperty]
        private string title1;
        [ObservableProperty]
        private string title2;

        [ObservableProperty]
        private ImageSource imageMaui;

        [ObservableProperty]
        bool isRefreshing;


        public ICommand RefreshCommand => new AsyncCommand(() => LoadServiceAsync());


        public NewPageViewModel(IDatabaseService database)
        {
            ind = 0;
            rep = new ImagesRepositorio(database);
            RefreshCommand.Execute(null);
        }

        private async Task LoadServiceAsync()
        {
            ind++;
            Title1 = "Hello, World! : " + ind;
            Title2 = "Welcome to .NET Multi-platform App UI";

            try
            {
                //OK - sucess
                //ImageMaui = ImageSource.FromFile("dotnet_bot.png");

                //Problem
                var image = await rep.GetAsync(1);
                var result = ImageSource.FromStream(() => new MemoryStream(image.Thumbnail));
                ImageMaui = result;
            }
            catch (Exception ex)
            {
            }

            IsRefreshing = false;
        }
    }
}
