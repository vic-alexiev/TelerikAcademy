using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        /// <summary>
        /// Binary document size in bytes.
        /// </summary>
        public long? Size { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "size")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Size = null;
                }
                else
                {
                    this.Size = Int64.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
    }
}
