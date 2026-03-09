using Microsoft.Extensions.DependencyInjection;
using MxUI.Core.Services;
using MxUI.Core.Theme;

namespace MxUI.Core.Extensions;

/// <summary>
/// Extension methods for registering MxUI services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all MxUI services to the DI container.
    /// Call this in Program.cs: builder.Services.AddMxUI();
    /// </summary>
    public static IServiceCollection AddMxUI(this IServiceCollection services, 
        Action<MxUIOptions>? configure = null)
    {
        var options = new MxUIOptions();
        configure?.Invoke(options);

        // Theme service (scoped for per-circuit in Blazor Server)
        services.AddScoped<MxThemeService>();

        // Toast notification service
        services.AddScoped<MxToastService>();

        // Register default theme if provided
        if (options.DefaultTheme != null)
        {
            services.AddSingleton(options.DefaultTheme);
        }

        return services;
    }
}

/// <summary>
/// Options for configuring MxUI.
/// </summary>
public class MxUIOptions
{
    /// <summary>Default theme applied on startup.</summary>
    public MxTheme? DefaultTheme { get; set; }

    /// <summary>Enable dark mode toggle in all components.</summary>
    public bool EnableDarkMode { get; set; } = true;

    /// <summary>Enable CSS transitions for theme changes.</summary>
    public bool EnableTransitions { get; set; } = true;
}
