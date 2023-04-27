namespace MauiApp1.MainShell;

public partial class AppShell : Shell
{
    public static readonly TimeSpan TimeFlyoutCloses = TimeSpan.FromSeconds(0.5f);

    public AppShell()
	{
		InitializeComponent();
	}

    internal async Task CloseFlyoutAsync()
    {
        FlyoutIsPresented = false;
        await Task.Delay(TimeFlyoutCloses);
    }
}