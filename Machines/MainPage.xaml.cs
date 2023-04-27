using MauiApp1.Database;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;
	IDatabaseService databaseService;

	public MainPage(IDatabaseService database)
	{
        databaseService = database;

        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void NewPageClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new NewPage(databaseService));
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

