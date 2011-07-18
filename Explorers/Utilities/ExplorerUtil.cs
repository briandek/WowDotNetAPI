using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace WowDotNetAPI.Utilities
{
    public static class ExplorerUtil
    {
        public const string host = "battle.net";

        //Todo: Improve URL sanitizer
        //http://stackoverflow.com/questions/25259/how-do-you-include-a-webpage-title-as-part-of-a-webpage-url/25486#25486
        public static string SanitizeUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";

            url = Regex.Replace(url.Trim(), @"\s+", "-");
            url = Regex.Replace(url, "[#']", "");

            return url;
        }

        public static string GetJson(WebClient WebClient, string url)
        {
            return WebClient.DownloadString(url);
        }
    }
}
