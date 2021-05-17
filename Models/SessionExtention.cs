// Demo 7 - Shopping Cart; LV
// These extension methods enable session state to set and get serializable objects
// Source: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-5.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// add these namespaces

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CC_Sports.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            // if value is null, return null, else the deserialized object

            return (value == null) ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}