using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class PDFDocument : EncryptableDocument
    {
        public int? Pages { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "pages")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Pages = null;
                }
                else
                {
                    this.Pages = Int32.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }
    }
}
