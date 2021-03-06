using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartCore.ConfigCenter.Apollo.Util
{
    internal static class QueryUtils
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Build(IReadOnlyCollection<KeyValuePair<string, string>> source)
 
        {
            if (source == null || source.Count == 0)
            {
                return "";
            }
            var sb = new StringBuilder(source.Count * 32);

            foreach (var kv in source)
            {
                sb.Append('&');
                sb.Append(WebUtility.UrlEncode(kv.Key));
                sb.Append('=');
                sb.Append(WebUtility.UrlEncode(kv.Value));
            }

            return sb.ToString(1, sb.Length - 1);
        }
    }
}
