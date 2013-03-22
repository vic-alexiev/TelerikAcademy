using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class MultimediaDocument : BinaryDocument
    {
        /// <summary>
        /// Document length in seconds.
        /// </summary>
        public int? Length { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "length")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Length = null;
                }
                else
                {
                    this.Length = Int32.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }
}
