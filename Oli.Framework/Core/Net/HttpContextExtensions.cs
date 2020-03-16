using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Oli.Framework.Core.Net
{
    public static class HttpContextExtensions
    {
        public static string GetRequestIp(this HttpContext context, bool tryUseXForwardHeader = true)
        {
            string ip = null;


            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>(context, "X-Forwarded-For").SplitCsv().FirstOrDefault();

            if (ip.IsNullOrWhitespace() && context.Connection?.RemoteIpAddress != null)
                ip = context.Connection.RemoteIpAddress.ToString();

            if (ip.IsNullOrWhitespace())
                ip = GetHeaderValueAs<string>(context, "REMOTE_ADDR");

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            return ip;
        }

        private static T GetHeaderValueAs<T>(HttpContext context, string headerName)
        {
            if (!(context.Request?.Headers?.TryGetValue(headerName, out var values) ?? false)) return default;

            var rawValues = values.ToString();
            if (!rawValues.IsNullOrWhitespace())
                return (T) Convert.ChangeType(values.ToString(), typeof(T));

            return default;
        }

        private static IEnumerable<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable()
                .Select(s => s.Trim())
                .ToList();
        }

        private static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}