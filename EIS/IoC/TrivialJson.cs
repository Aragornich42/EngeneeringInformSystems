using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public class TrivialJson : ITrivialIntf
    {
        public string TrivialSerializer(object trivialObject)
        {
            var props = trivialObject.GetProperties();

            var sb = new StringBuilder("{\n");
            foreach(var key in props.Keys)
            {
                sb.Append("\t");
                propToJson(key, props[key], ref sb);
            }
            sb.Append("}\n");

            return sb.ToString();
        }

        private void propToJson(string name, object value, ref StringBuilder sb)
        {
            sb.Append('"');
            sb.Append(name);
            sb.Append("\": ");
            if (value == null)
            {
                sb.Append("null,\n");
            }
            else
            {
                if (value.GetType() == typeof(string))
                {
                    sb.Append("\"");
                    sb.Append(value);
                    sb.Append("\",\n");
                }
                else
                {
                    sb.Append(value.ToString());
                    sb.Append(",\n");
                }
            }
        }
    }
}
