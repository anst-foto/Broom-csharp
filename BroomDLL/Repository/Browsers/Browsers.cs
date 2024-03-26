using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using BroomDLL.Browsers;

namespace BroomDLL
{
    public class Browser : Item
    {
        public static event Message Error;

        private static Dictionary<string, Action<string>> browsers = new Dictionary<string, Action<string>>()
        {
            {"Google Chrome", GoogleChrome.Clear},
            {"Chromium", Chromium.Clear},
            {"Yandex", Yandex.Clear},
            {"Internet Explorer", InternetExplorer.Clear},
            {"Microsoft Edge", MicrosoftEdge.Clear},
            {"Vivaldi", Vivaldi.Clear},
            {"Mozilla", Mozilla.Clear},
            {"Opera", Opera.Clear},
        };

        public override void Clear(string dir)
        {
            foreach (string browser in GetBrowsers())
            {
                if (browsers.TryGetValue(browser, out Action<string> bc))
                {
                    Broom.ClearItem("Очистка кэша", browser, browsers[browser]);
                }
                else
                {
                    Error?.Invoke("Неизвестный браузер " + browser);
                }
            }
        }

        public static IEnumerable<string> GetBrowsers()
        {
            string browsersRegistryKeyPath = @"SOFTWARE\WOW6432Node\Clients\StartMenuInternet";

            using RegistryKey browsersKey = Registry.LocalMachine.OpenSubKey(browsersRegistryKeyPath);
            foreach (string browserKeyName in browsersKey.GetSubKeyNames())
            {
                using RegistryKey browserKey = browsersKey.OpenSubKey(browserKeyName);
                string browserName = browserKey.GetValue(null).ToString();
                yield return browserName;
            }
        }

    }
}
