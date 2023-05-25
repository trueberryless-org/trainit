namespace View.Services;

public class ThemeProvider
{
    public MudTheme Theme = new MudTheme()
    {
        PaletteDark = new PaletteDark()
        {
            Background = "#1f1f1f",
            DrawerBackground = "#2d2f31",
            BackgroundGrey = "#131313",
            Surface = "#28292a"
        }
    };

    public event Action? ThemeChange;
    public bool ThemeMenuShown { get; set; }
    public bool SideOpenMini { get; set; } = true;
    public bool SideOpen { get; set; }
    public ESideMenuState ESideMenuState { get; set; } = ESideMenuState.Responsive;
    
    public void UpdateThemeMenu(bool shown) {
        ThemeMenuShown = shown;
        ThemeChange?.Invoke();
    }
    
    public void UpdateSideMenu(ESideMenuState state) {
        switch (state) {
            case ESideMenuState.Minimized:
                SideOpenMini = false;
                SideOpen = false;
                break;
            case ESideMenuState.Responsive:
                SideOpenMini = true;
                SideOpen = false;
                break;
            case ESideMenuState.Maximized:
                SideOpenMini = false;
                SideOpen = true;
                break;
            default:
                throw new NotSupportedException();
        }

        ESideMenuState = state;
        ThemeChange?.Invoke();
    }
}

public enum ESideMenuState {
    Minimized,
    Responsive,
    Maximized
}