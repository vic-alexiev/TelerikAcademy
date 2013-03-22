using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public int? Characters { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "chars")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Characters = null;
                }
                else
                {
                    this.Characters = Int32.Parse(value);
                }
            }
            else
            {
                base.LoadProperty(name, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.Characters));
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
