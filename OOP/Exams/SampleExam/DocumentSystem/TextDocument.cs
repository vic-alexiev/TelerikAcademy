using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        public string Charset { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "charset")
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(name, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
