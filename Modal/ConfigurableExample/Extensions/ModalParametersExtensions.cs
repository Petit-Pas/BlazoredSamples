using Blazored.Modal;
using ConfigurableExample.Components.Modals;
using ConfigurableExample.Components.Pages;
using static ConfigurableExample.Components.Pages.ModalSample;

namespace ConfigurableExample.Extensions;

public static class ModalParametersExtensions
{
    public static ModalParameters AddContentSize(this ModalParameters param, ModalSample caller)
    {
        return param.Add(nameof(SimpleModal.Message), caller.ContentSize switch
        {
            ModalContentSize.Small => caller.SmallContent,
            ModalContentSize.Normal => caller.NormalContent,
            ModalContentSize.Huge => caller.HugeContent,
            _ => throw new ArgumentOutOfRangeException($"unrecognized value for ContentSize: [{caller.ContentSize}]")
        });
    }

    public static ModalOptions AddModalWidth(this ModalOptions options, ModalSample caller)
    {
        options.Size = caller.Width switch
        {
            ModalWidth.Automatic => ModalSize.Automatic,
            ModalWidth.Small => ModalSize.Small,
            ModalWidth.Medium => ModalSize.Medium,
            ModalWidth.Large => ModalSize.Large,
            ModalWidth.ExtraLarge => ModalSize.ExtraLarge,
            ModalWidth.Custom => ModalSize.Custom,
            _ => throw new ArgumentOutOfRangeException($"unrecognized value for ModalWidth: [{caller.Width}]"),
        };
        if (caller.Width == ModalWidth.Custom)
        {
            options.SizeCustomClass = "custom-modal-width";
        }
        return options;
    }

    public static ModalOptions AddModalPosition(this ModalOptions options, ModalSample caller)
    {
        options.Position = caller.Position switch
        {
            ModalSample.ModalPosition.TopLeft => Blazored.Modal.ModalPosition.TopLeft,
            ModalSample.ModalPosition.TopRight => Blazored.Modal.ModalPosition.TopRight,
            ModalSample.ModalPosition.TopCenter => Blazored.Modal.ModalPosition.TopCenter,
            ModalSample.ModalPosition.Middle => Blazored.Modal.ModalPosition.Middle,
            ModalSample.ModalPosition.BottomLeft => Blazored.Modal.ModalPosition.BottomLeft,
            ModalSample.ModalPosition.BottomRight => Blazored.Modal.ModalPosition.BottomRight,
            ModalSample.ModalPosition.Custom => Blazored.Modal.ModalPosition.Custom,
            _ => throw new ArgumentOutOfRangeException($"unrecognized value for ModalPosition: [{caller.Position}]"),
        };
        if (caller.Position == ModalSample.ModalPosition.Custom)
        {
            options.PositionCustomClass = "custom-modal-position";
        }
        return options;
    }

    public static ModalOptions AddHeaderVisibilityOptions(this ModalOptions options, ModalSample caller)
    {
        switch (caller.HeaderVisibility)
        {
            case HeaderOption.HideCloseButton:
                options.HideCloseButton = true; 
                break;
            case HeaderOption.HideAllHeader:
                options.HideHeader = true; 
                break;
            case HeaderOption.ShowAll:
            default:
                break;
        }

        return options;
    }
    
    public static ModalOptions AddBackgroundCLickComportment(this ModalOptions options, ModalSample caller)
    {
        options.DisableBackgroundCancel = !caller.BackgroundClickShouldClose;
        return options;
    }

    public static ModalOptions AddFocusTrapComportment(this ModalOptions options, ModalSample caller)
    {
        options.ActivateFocusTrap = caller.ShouldTrapFocus;
        return options;
    }
}
