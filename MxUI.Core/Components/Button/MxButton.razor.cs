using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MxUI.Core.Components;

public partial class MxButton : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public RenderFragment? IconLeft { get; set; }
    [Parameter] public RenderFragment? IconRight { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    [Parameter] public MxButtonVariant Variant { get; set; } = MxButtonVariant.Primary;
    [Parameter] public MxButtonSize Size { get; set; } = MxButtonSize.Medium;
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool Loading { get; set; }
    [Parameter] public bool FullWidth { get; set; }
    [Parameter] public string ButtonType { get; set; } = "button";
    [Parameter] public string? Class { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    private string ComputedClasses
    {
        get
        {
            var classes = new List<string> { "mx-btn" };

            // Variant styles
            classes.Add(Variant switch
            {
                MxButtonVariant.Primary =>
                    "bg-primary-600 text-white hover:bg-primary-700 active:bg-primary-800 shadow-sm",
                MxButtonVariant.Secondary =>
                    "bg-secondary-600 text-white hover:bg-secondary-700 active:bg-secondary-800 shadow-sm",
                MxButtonVariant.Outline =>
                    "border-2 border-primary-500 text-primary-600 hover:bg-primary-50 active:bg-primary-100",
                MxButtonVariant.Ghost =>
                    "text-primary-600 hover:bg-primary-50 active:bg-primary-100",
                MxButtonVariant.Danger =>
                    "bg-danger-600 text-white hover:bg-danger-700 active:bg-danger-800 shadow-sm",
                MxButtonVariant.Success =>
                    "bg-success-600 text-white hover:bg-success-700 active:bg-success-800 shadow-sm",
                MxButtonVariant.Warning =>
                    "bg-warning-500 text-white hover:bg-warning-600 active:bg-warning-700 shadow-sm",
                MxButtonVariant.Soft =>
                    "bg-primary-50 text-primary-700 hover:bg-primary-100 active:bg-primary-200",
                MxButtonVariant.Link =>
                    "text-primary-600 hover:text-primary-700 underline-offset-4 hover:underline p-0",
                _ => ""
            });

            // Size styles
            classes.Add(Size switch
            {
                MxButtonSize.ExtraSmall => "px-2 py-1 text-xs rounded-sm gap-1",
                MxButtonSize.Small      => "px-3 py-1.5 text-xs rounded-md gap-1.5",
                MxButtonSize.Medium     => "px-4 py-2 text-sm rounded-md gap-2",
                MxButtonSize.Large      => "px-5 py-2.5 text-base rounded-lg gap-2",
                MxButtonSize.ExtraLarge => "px-6 py-3 text-lg rounded-lg gap-2.5",
                _ => ""
            });

            if (FullWidth) classes.Add("w-full");
            if (Loading) classes.Add("cursor-wait");
            if (!string.IsNullOrEmpty(Class)) classes.Add(Class);

            return string.Join(" ", classes);
        }
    }

    private async Task HandleClick(MouseEventArgs args)
    {
        if (!Disabled && !Loading && OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync(args);
        }
    }
}

public enum MxButtonVariant
{
    Primary, Secondary, Outline, Ghost, Danger, 
    Success, Warning, Soft, Link
}

public enum MxButtonSize
{
    ExtraSmall, Small, Medium, Large, ExtraLarge
}
