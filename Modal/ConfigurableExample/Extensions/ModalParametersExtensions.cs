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
}
