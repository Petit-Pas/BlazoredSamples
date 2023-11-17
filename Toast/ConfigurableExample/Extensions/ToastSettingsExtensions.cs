using System.Runtime.CompilerServices;
using Blazored.Toast.Configuration;
using static ConfigurableExample.Components.Pages.Home;
using IconType = Blazored.Toast.Configuration.IconType;

namespace ConfigurableExample.Extensions
{
    public static class ToastSettingsExtensions
    {
        public static ToastSettings ConfigureTimeout(this ToastSettings settings, bool disableTimeout, int timeoutDuration, bool pausesTimeoutOnMouseOver, int extendedTimeOut)
        {
            settings.DisableTimeout = disableTimeout;
            settings.Timeout = timeoutDuration;
            settings.PauseProgressOnHover = pausesTimeoutOnMouseOver;
            settings.ExtendedTimeout = extendedTimeOut;

            return settings;
        }

        public static ToastSettings ConfigureLayout(this ToastSettings settings, bool showProgressBar, bool showCloseButton)
        {
            settings.ShowProgressBar = showProgressBar;
            settings.ShowCloseButton = showCloseButton;
            return settings;
        }


        public static ToastSettings ConfigureIcon(this ToastSettings settings, Components.Pages.Home.IconType iconType)
        {
            if (iconType == Components.Pages.Home.IconType.Default)
            {
                return settings;
            }
            
            if (iconType == Components.Pages.Home.IconType.None)
            {
                settings.IconType = IconType.None;
            }
            else
            {
                settings.IconType = IconType.Material;
                settings.Icon = iconType switch
                {
                    Components.Pages.Home.IconType.MaterialInfo => "info",
                    Components.Pages.Home.IconType.MaterialSuccess => "done",
                    Components.Pages.Home.IconType.MaterialWarning => "priority_high",
                    Components.Pages.Home.IconType.MaterialError => "report",
                };
            }
            return settings;
        }

        public static ToastSettings ConfigurePosition(this ToastSettings settings, ToastPositions position)
        {
            if (position is not ToastPositions.Default)
            {
                settings.Position = position switch
                {
                    ToastPositions.TopLeft => ToastPosition.TopLeft,
                    ToastPositions.TopCenter => ToastPosition.TopCenter,
                    ToastPositions.TopRight => ToastPosition.TopRight,
                    ToastPositions.BottomLeft => ToastPosition.BottomLeft,
                    ToastPositions.BottomCenter => ToastPosition.BottomCenter,
                    ToastPositions.BottomRight => ToastPosition.BottomRight,
                    _ => throw new NotImplementedException()
                };
            }
            return settings;
        }
    }
}
