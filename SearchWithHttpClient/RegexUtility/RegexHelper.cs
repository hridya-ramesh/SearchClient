using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SearchWithHttpClient.RegexUtility
{
    public static class RegexHelper
    {
        public static List<Uri> GetValidUri(string result)
        {
            string anchorPattern = @"<a.*?href.*?\/url\?q=(?<url>.*?)>";
            List<Uri> uris = new List<Uri>();
            MatchCollection matches = Regex.Matches(result, anchorPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    string url = m.Groups["url"].Value;
                    Uri testUri = null;
                    if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out testUri))
                    {
                        uris.Add(testUri);
                    }
                }
            }
            return uris;
        }
    }
}