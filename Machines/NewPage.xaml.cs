using MauiApp1.Database;
using MauiApp1.Machines;

namespace MauiApp1;

public partial class NewPage : ContentPage
{
	public NewPage(IDatabaseService database)
	{
		InitializeComponent();
        BindingContext = new NewPageViewModel(database);
    }

    protected override void OnAppearing()
    {
        App.SetNavigationRoot(App.EnumNavigationRoot.navMachine, this);
        base.OnAppearing();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}