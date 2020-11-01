using System;
using Xamarin.Essentials;

namespace Mobile.Core.Services.OpenUrl
{
    public class OpenUrlService : IOpenUrlService
    {
        public void OpenUrl(string url)
        {
            Launcher.OpenAsync(new Uri(url));
        }
    }
}
