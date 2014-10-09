using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GriklyApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class UrlHelpers
    {
        /// <summary>
        /// To the query string.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            Dictionary<string, object> properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            List<string> propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (string key in propertyNames)
            {
                Type valueType = properties[key].GetType();
                Type valueElemType = valueType.IsGenericType
                    ? valueType.GetGenericArguments()[0]
                    : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }
    }
}