using MauiApp1.MainShell;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    #region Navigation

    public static AppShell SetAppShell => Current.MainPage as AppShell;

    private static NavigableElement navigationRoot;
    private static NavigableElement navigationMachinesRoot;
    private static NavigableElement navigationInspectionsRoot;

    public enum EnumNavigationRoot { navMachine, navInspections };

    private static bool _istapped = false;
    public static bool disableButtonMenuItem = false;

    /// <summary>
    /// </summary>
    /// <param name="_root"></param>
    /// <param name="element"></param>
    public static void SetNavigationRoot(EnumNavigationRoot _root, NavigableElement element)
    {
        disableButtonMenuItem = false;
        switch (_root)
        {
            case EnumNavigationRoot.navMachine:
                if (navigationMachinesRoot != null)
                    element = navigationMachinesRoot;
                else
                    navigationMachinesRoot = element;
                break;
            case EnumNavigationRoot.navInspections:
                if (navigationInspectionsRoot != null)
                    element = navigationInspectionsRoot;
                else
                    navigationInspectionsRoot = element;
                break;
            default:
                break;
        }

        navigationRoot = element;
    }
    internal static ShellSection GetShellSection(Element element)
    {
        if (element == null)
        {
            return null;
        }

        var parent = element;
        var parentSection = parent as ShellSection;

        while (parentSection == null && parent != null)
        {
            parent = parent.Parent;
            parentSection = parent as ShellSection;
        }

        return parentSection;
    }

    public static NavigableElement NavigationRoot
    {
        get => GetShellSection(navigationRoot) ?? navigationRoot;
        set => navigationRoot = value;
    }

    internal static async Task NavigateToAsync(Page page, bool closeFlyout = false)
    {
        if (_istapped || disableButtonMenuItem)
            return;

        _istapped = true;

        if (closeFlyout)
        {
            await SetAppShell.CloseFlyoutAsync();
        }

        try
        {
            await NavigationRoot.Navigation.PushAsync(page);
        }
        catch (Exception ex)
        {
        }
        _istapped = false;
    }


    internal static async Task NavigateModallyBackAsync()
    {
        await NavigationRoot.Navigation.PopModalAsync();
    }

    internal static async Task NavigateModallyToAsync(Page page, bool animated = true)
    {
        await NavigationRoot.Navigation.PushModalAsync(page, animated).ConfigureAwait(false);
    }


    public static async Task NavigateBackAsync()
    {
        await Current.MainPage.Navigation.PopAsync();
    }

    #endregion
}
