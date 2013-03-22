using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string name, string value)
        {
            if (name == "name")
            {
                this.Name = value;
            }
            else if (name == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new ArgumentException(String.Format("Key '{0}' not found", name));
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);

            properties.Sort((p, q) => p.Key.CompareTo(q.Key));

            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);

            result.Append("[");

            foreach (KeyValuePair<string, object> property in properties)
            {
                if (property.Value != null)
                {
                    result.AppendFormat("{0}={1};", property.Key, property.Value);
                }
            }

            // remove the extra semicolon at the end
            result.Length--;

            result.Append("]");

            return result.ToString();
        }
    }
}
