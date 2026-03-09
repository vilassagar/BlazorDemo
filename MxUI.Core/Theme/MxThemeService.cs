using Microsoft.JSInterop;

namespace MxUI.Core.Theme;

/// <summary>
/// Service for managing theme state and runtime switching.
/// Injects CSS variables into the DOM and persists preference.
/// </summary>
public class MxThemeService : IAsyncDisposable
{
    private readonly IJSRuntime _js;
    private MxTheme _currentTheme;
    private IJSObjectReference? _module;

    public event Action<MxTheme>? OnThemeChanged;
    public MxTheme CurrentTheme => _currentTheme;

    public MxThemeService(IJSRuntime js)
    {
        _js = js;
        _currentTheme = MxThemePresets.Light;
    }

    /// <summary>
    /// Initialize theme service - loads saved preference or uses default.
    /// Call this once in your App.razor or MainLayout OnAfterRenderAsync.
    /// </summary>
    public async Task InitializeAsync(MxTheme? defaultTheme = null)
    {
        _module = await _js.InvokeAsync<IJSObjectReference>(
            "import", "./_content/MxUI.Core/js/mxui.js");

        // Try to load saved theme preference
        var savedThemeName = await _module.InvokeAsync<string?>("MxUI.getThemePreference");

        if (savedThemeName != null)
        {
            _currentTheme = savedThemeName switch
            {
                "dark" => MxThemePresets.Dark,
                "healthcare" => MxThemePresets.Healthcare,
                "compact" => MxThemePresets.Compact,
                _ => defaultTheme ?? MxThemePresets.Light
            };
        }
        else
        {
            _currentTheme = defaultTheme ?? MxThemePresets.Light;
        }

        await ApplyThemeAsync(_currentTheme);
    }

    /// <summary>
    /// Switch to a different theme at runtime.
    /// </summary>
    public async Task SetThemeAsync(MxTheme theme)
    {
        _currentTheme = theme;
        await ApplyThemeAsync(theme);
        OnThemeChanged?.Invoke(theme);
    }

    /// <summary>
    /// Toggle between light and dark themes.
    /// </summary>
    public async Task ToggleDarkModeAsync()
    {
        var newTheme = _currentTheme.Name == "dark" 
            ? MxThemePresets.Light 
            : MxThemePresets.Dark;
        await SetThemeAsync(newTheme);
    }

    /// <summary>
    /// Apply a custom theme by merging overrides onto the current theme.
    /// </summary>
    public async Task ApplyCustomThemeAsync(Action<MxTheme> configure)
    {
        var customTheme = new MxTheme();
        configure(customTheme);
        await SetThemeAsync(customTheme);
    }

    private async Task ApplyThemeAsync(MxTheme theme)
    {
        if (_module != null)
        {
            var cssVars = theme.ToCssVariables();
            await _module.InvokeVoidAsync("MxUI.applyTheme", cssVars, theme.Name);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            await _module.DisposeAsync();
        }
    }
}
