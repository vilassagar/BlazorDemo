namespace MxUI.Core.Theme;

/// <summary>
/// Defines a complete theme configuration using CSS custom properties.
/// Tailwind classes reference these variables, enabling runtime theme switching.
/// </summary>
public class MxTheme
{
    public string Name { get; set; } = "default";
    
    // ──────────────────────────────────────────────
    // Brand Colors (map to Tailwind's color system)
    // ──────────────────────────────────────────────
    public MxColorScale Primary { get; set; } = new()
    {
        C50 = "#eff6ff", C100 = "#dbeafe", C200 = "#bfdbfe",
        C300 = "#93c5fd", C400 = "#60a5fa", C500 = "#3b82f6",
        C600 = "#2563eb", C700 = "#1d4ed8", C800 = "#1e40af", C900 = "#1e3a8a"
    };

    public MxColorScale Secondary { get; set; } = new()
    {
        C50 = "#f5f3ff", C100 = "#ede9fe", C200 = "#ddd6fe",
        C300 = "#c4b5fd", C400 = "#a78bfa", C500 = "#8b5cf6",
        C600 = "#7c3aed", C700 = "#6d28d9", C800 = "#5b21b6", C900 = "#4c1d95"
    };

    public MxColorScale Success { get; set; } = new()
    {
        C50 = "#f0fdf4", C100 = "#dcfce7", C200 = "#bbf7d0",
        C300 = "#86efac", C400 = "#4ade80", C500 = "#22c55e",
        C600 = "#16a34a", C700 = "#15803d", C800 = "#166534", C900 = "#14532d"
    };

    public MxColorScale Danger { get; set; } = new()
    {
        C50 = "#fef2f2", C100 = "#fee2e2", C200 = "#fecaca",
        C300 = "#fca5a5", C400 = "#f87171", C500 = "#ef4444",
        C600 = "#dc2626", C700 = "#b91c1c", C800 = "#991b1b", C900 = "#7f1d1d"
    };

    public MxColorScale Warning { get; set; } = new()
    {
        C50 = "#fffbeb", C100 = "#fef3c7", C200 = "#fde68a",
        C300 = "#fcd34d", C400 = "#fbbf24", C500 = "#f59e0b",
        C600 = "#d97706", C700 = "#b45309", C800 = "#92400e", C900 = "#78350f"
    };

    public MxColorScale Neutral { get; set; } = new()
    {
        C50 = "#f9fafb", C100 = "#f3f4f6", C200 = "#e5e7eb",
        C300 = "#d1d5db", C400 = "#9ca3af", C500 = "#6b7280",
        C600 = "#4b5563", C700 = "#374151", C800 = "#1f2937", C900 = "#111827"
    };

    // ──────────────────────────────────────────────
    // Semantic Tokens (surfaces, text, borders)
    // ──────────────────────────────────────────────
    public string BgBase { get; set; } = "#ffffff";
    public string BgSurface { get; set; } = "#f9fafb";
    public string BgMuted { get; set; } = "#f3f4f6";
    public string TextPrimary { get; set; } = "#111827";
    public string TextSecondary { get; set; } = "#6b7280";
    public string TextMuted { get; set; } = "#9ca3af";
    public string BorderDefault { get; set; } = "#e5e7eb";
    public string BorderFocused { get; set; } = "#3b82f6";

    // ──────────────────────────────────────────────
    // Typography
    // ──────────────────────────────────────────────
    public string FontFamily { get; set; } = "'Inter', 'Segoe UI', system-ui, sans-serif";
    public string FontFamilyMono { get; set; } = "'JetBrains Mono', 'Fira Code', monospace";
    public string FontSizeBase { get; set; } = "0.875rem";     // 14px
    public string FontSizeSm { get; set; } = "0.75rem";        // 12px
    public string FontSizeLg { get; set; } = "1rem";           // 16px
    public string FontSizeXl { get; set; } = "1.25rem";        // 20px
    public string FontSize2Xl { get; set; } = "1.5rem";        // 24px

    // ──────────────────────────────────────────────
    // Spacing & Radius
    // ──────────────────────────────────────────────
    public string RadiusSm { get; set; } = "0.25rem";
    public string RadiusMd { get; set; } = "0.375rem";
    public string RadiusLg { get; set; } = "0.5rem";
    public string RadiusXl { get; set; } = "0.75rem";
    public string RadiusFull { get; set; } = "9999px";

    // ──────────────────────────────────────────────
    // Shadows
    // ──────────────────────────────────────────────
    public string ShadowSm { get; set; } = "0 1px 2px 0 rgb(0 0 0 / 0.05)";
    public string ShadowMd { get; set; } = "0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1)";
    public string ShadowLg { get; set; } = "0 10px 15px -3px rgb(0 0 0 / 0.1), 0 4px 6px -4px rgb(0 0 0 / 0.1)";

    // ──────────────────────────────────────────────
    // Transitions
    // ──────────────────────────────────────────────
    public string TransitionFast { get; set; } = "150ms cubic-bezier(0.4, 0, 0.2, 1)";
    public string TransitionBase { get; set; } = "200ms cubic-bezier(0.4, 0, 0.2, 1)";
    public string TransitionSlow { get; set; } = "300ms cubic-bezier(0.4, 0, 0.2, 1)";

    /// <summary>
    /// Generates CSS custom properties from this theme configuration.
    /// </summary>
    public string ToCssVariables()
    {
        return $@"
:root {{
    /* Primary */
    --mx-primary-50: {Primary.C50};  --mx-primary-100: {Primary.C100};
    --mx-primary-200: {Primary.C200}; --mx-primary-300: {Primary.C300};
    --mx-primary-400: {Primary.C400}; --mx-primary-500: {Primary.C500};
    --mx-primary-600: {Primary.C600}; --mx-primary-700: {Primary.C700};
    --mx-primary-800: {Primary.C800}; --mx-primary-900: {Primary.C900};

    /* Secondary */
    --mx-secondary-50: {Secondary.C50};  --mx-secondary-100: {Secondary.C100};
    --mx-secondary-200: {Secondary.C200}; --mx-secondary-300: {Secondary.C300};
    --mx-secondary-400: {Secondary.C400}; --mx-secondary-500: {Secondary.C500};
    --mx-secondary-600: {Secondary.C600}; --mx-secondary-700: {Secondary.C700};
    --mx-secondary-800: {Secondary.C800}; --mx-secondary-900: {Secondary.C900};

    /* Success */
    --mx-success-50: {Success.C50};  --mx-success-500: {Success.C500};
    --mx-success-600: {Success.C600}; --mx-success-700: {Success.C700};

    /* Danger */
    --mx-danger-50: {Danger.C50};  --mx-danger-500: {Danger.C500};
    --mx-danger-600: {Danger.C600}; --mx-danger-700: {Danger.C700};

    /* Warning */
    --mx-warning-50: {Warning.C50};  --mx-warning-500: {Warning.C500};
    --mx-warning-600: {Warning.C600}; --mx-warning-700: {Warning.C700};

    /* Neutral */
    --mx-neutral-50: {Neutral.C50};   --mx-neutral-100: {Neutral.C100};
    --mx-neutral-200: {Neutral.C200};  --mx-neutral-300: {Neutral.C300};
    --mx-neutral-400: {Neutral.C400};  --mx-neutral-500: {Neutral.C500};
    --mx-neutral-600: {Neutral.C600};  --mx-neutral-700: {Neutral.C700};
    --mx-neutral-800: {Neutral.C800};  --mx-neutral-900: {Neutral.C900};

    /* Semantic */
    --mx-bg-base: {BgBase};
    --mx-bg-surface: {BgSurface};
    --mx-bg-muted: {BgMuted};
    --mx-text-primary: {TextPrimary};
    --mx-text-secondary: {TextSecondary};
    --mx-text-muted: {TextMuted};
    --mx-border-default: {BorderDefault};
    --mx-border-focused: {BorderFocused};

    /* Typography */
    --mx-font-family: {FontFamily};
    --mx-font-mono: {FontFamilyMono};
    --mx-text-base: {FontSizeBase};
    --mx-text-sm: {FontSizeSm};
    --mx-text-lg: {FontSizeLg};
    --mx-text-xl: {FontSizeXl};
    --mx-text-2xl: {FontSize2Xl};

    /* Radius */
    --mx-radius-sm: {RadiusSm};
    --mx-radius-md: {RadiusMd};
    --mx-radius-lg: {RadiusLg};
    --mx-radius-xl: {RadiusXl};
    --mx-radius-full: {RadiusFull};

    /* Shadows */
    --mx-shadow-sm: {ShadowSm};
    --mx-shadow-md: {ShadowMd};
    --mx-shadow-lg: {ShadowLg};

    /* Transitions */
    --mx-transition-fast: {TransitionFast};
    --mx-transition-base: {TransitionBase};
    --mx-transition-slow: {TransitionSlow};
}}";
    }
}

/// <summary>
/// Represents a color scale with 50-900 shades.
/// </summary>
public class MxColorScale
{
    public string C50 { get; set; } = "#f9fafb";
    public string C100 { get; set; } = "#f3f4f6";
    public string C200 { get; set; } = "#e5e7eb";
    public string C300 { get; set; } = "#d1d5db";
    public string C400 { get; set; } = "#9ca3af";
    public string C500 { get; set; } = "#6b7280";
    public string C600 { get; set; } = "#4b5563";
    public string C700 { get; set; } = "#374151";
    public string C800 { get; set; } = "#1f2937";
    public string C900 { get; set; } = "#111827";
}
