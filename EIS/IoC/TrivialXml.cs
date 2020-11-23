using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace IoC
{
    public class TrivialXml : ITrivialIntf
    {
        public string TrivialSerializer(object trivialObject)
        {
            var props = trivialObject.GetProperties();

            var sb = new StringBuilder("<");
            sb.Append(trivialObject.GetType().Name);
            sb.Append(">\n");

            foreach (var key in props.Keys)
            {
                sb.Append("\t");
                propToXml(key, props[key], ref sb);
            }

            sb.Append("</");
            sb.Append(trivialObject.GetType().Name);
            sb.Append(">\n");

            return sb.ToString();
        }

        private void propToXml(string name, object value, ref StringBuilder sb)
        {
            sb.Append('<');
            sb.Append(name);
            if (value == null)
                sb.Append(" />\n");
            else
            {
                sb.Append('>');
                sb.Append(value.ToString());
                sb.Append("</");
                sb.Append(name);
                sb.Append(">\n");
            }
        }
    }
}
