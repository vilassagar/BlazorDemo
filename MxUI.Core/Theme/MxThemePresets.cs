namespace MxUI.Core.Theme;

/// <summary>
/// Pre-built theme presets for common use cases.
/// </summary>
public static class MxThemePresets
{
    /// <summary>Default light theme - clean, professional, healthcare-appropriate.</summary>
    public static MxTheme Light => new()
    {
        Name = "light",
        Primary = new MxColorScale
        {
            C50 = "#eff6ff", C100 = "#dbeafe", C200 = "#bfdbfe",
            C300 = "#93c5fd", C400 = "#60a5fa", C500 = "#3b82f6",
            C600 = "#2563eb", C700 = "#1d4ed8", C800 = "#1e40af", C900 = "#1e3a8a"
        },
        BgBase = "#ffffff",
        BgSurface = "#f9fafb",
        BgMuted = "#f3f4f6",
        TextPrimary = "#111827",
        TextSecondary = "#6b7280",
        TextMuted = "#9ca3af",
        BorderDefault = "#e5e7eb",
        BorderFocused = "#3b82f6"
    };

    /// <summary>Dark theme - eye-friendly for extended use.</summary>
    public static MxTheme Dark => new()
    {
        Name = "dark",
        Primary = new MxColorScale
        {
            C50 = "#172554", C100 = "#1e3a8a", C200 = "#1e40af",
            C300 = "#1d4ed8", C400 = "#2563eb", C500 = "#3b82f6",
            C600 = "#60a5fa", C700 = "#93c5fd", C800 = "#bfdbfe", C900 = "#dbeafe"
        },
        BgBase = "#0f172a",
        BgSurface = "#1e293b",
        BgMuted = "#334155",
        TextPrimary = "#f1f5f9",
        TextSecondary = "#94a3b8",
        TextMuted = "#64748b",
        BorderDefault = "#334155",
        BorderFocused = "#60a5fa"
    };

    /// <summary>Healthcare theme - calming blues and greens, WCAG AA compliant.</summary>
    public static MxTheme Healthcare => new()
    {
        Name = "healthcare",
        Primary = new MxColorScale
        {
            C50 = "#ecfeff", C100 = "#cffafe", C200 = "#a5f3fc",
            C300 = "#67e8f9", C400 = "#22d3ee", C500 = "#0891b2",
            C600 = "#0e7490", C700 = "#155e75", C800 = "#164e63", C900 = "#083344"
        },
        Secondary = new MxColorScale
        {
            C50 = "#f0fdfa", C100 = "#ccfbf1", C200 = "#99f6e4",
            C300 = "#5eead4", C400 = "#2dd4bf", C500 = "#14b8a6",
            C600 = "#0d9488", C700 = "#0f766e", C800 = "#115e59", C900 = "#134e4a"
        },
        BgBase = "#ffffff",
        BgSurface = "#f0fdfa",
        BgMuted = "#ecfeff",
        TextPrimary = "#083344",
        TextSecondary = "#155e75",
        TextMuted = "#94a3b8",
        BorderDefault = "#cffafe",
        BorderFocused = "#0891b2"
    };

    /// <summary>Compact/Dense theme for data-heavy dashboards.</summary>
    public static MxTheme Compact => new()
    {
        Name = "compact",
        FontSizeBase = "0.8125rem",   // 13px
        FontSizeSm = "0.6875rem",     // 11px
        FontSizeLg = "0.875rem",      // 14px
        RadiusSm = "0.125rem",
        RadiusMd = "0.25rem",
        RadiusLg = "0.375rem"
    };
}
