using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IoC
{
    internal static class TrivialHelper
    {
        internal static Dictionary<string, object> GetProperties(this object obj)
        {
            var type = obj.GetType();
            var props = type.GetProperties()
                .Where(prop => prop.CanRead)
                .OrderBy(prop => prop.Name)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj));
            return props;
        }
    }
}
