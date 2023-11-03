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

    public static ModalOptions ApplyStyle(this ModalOptions options, ModalSample caller)
    {
        options.Class = caller.Style switch
        {
            ModalStyle.Default => "",
            // We keep the default blazored-modal & size-medium for this one because we just build on the existing style for the sake of the example.
            // Our style in this case only applies to the content, since the body of the modal remains the same
            ModalStyle.Dark => "blazored-modal size-medium dark-modal", 
            // That one we fully build from scratch (go check app.css)
            ModalStyle.Rainbow => "rainbow-modal",
            _ => throw new ArgumentOutOfRangeException($"unrecognized value for ModalOptions: [{caller.Style}]")
        };
        return options;
    }

    public static ModalOptions ApplyAnimation(this ModalOptions options, ModalSample caller)
    {
        options.AnimationType = caller.ShouldFadeIn ? ModalAnimationType.FadeInOut : ModalAnimationType.None;
        return options;
    }


    public static ModalOptions ApplyOverlay(this ModalOptions options, ModalSample caller)
    {
        options.OverlayCustomClass = caller.ShouldUseDefaultOverlay ? "" : "custom-modal-overlay";
        return options;
    }
}
