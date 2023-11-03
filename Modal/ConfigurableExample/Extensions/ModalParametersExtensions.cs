using Blazored.Modal;
using ConfigurableExample.Components.Modals;
using ConfigurableExample.Components.Pages;
using static ConfigurableExample.Components.Pages.ModalSample;

namespace ConfigurableExample.Extensions;

public static class ModalParametersExtensions
{
    public static ModalParameters AddContentSize(this ModalParameters param, ModalSample caller)
    {
        return param.Add(nameof(SimpleModal.Message), caller._contentSize switch
        {
            ModalContentSize.Small => caller._smallContent,
            ModalContentSize.Normal => caller._normalContent,
            ModalContentSize.Huge => caller._hugeContent,
            _ => throw new ArgumentOutOfRangeException($"unrecognized value for ContentSize: [{caller._contentSize}]")
        });
    }
}
