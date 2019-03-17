using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.UI.Extensions
{
    public static class SessionExtensionMethod
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string data = session.GetString(key);

            return (String.IsNullOrEmpty(data)) ? null : (JsonConvert.DeserializeObject<T>(data));
        }
    }
}
