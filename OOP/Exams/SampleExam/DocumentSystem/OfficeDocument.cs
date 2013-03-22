using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class OfficeDocument : EncryptableDocument
    {
        public string Version { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(name, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }

    }
}
