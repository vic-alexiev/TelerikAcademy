using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        public int? Rows { get; protected set; }
        public int? Columns { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "rows")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Rows = null;
                }
                else
                {
                    this.Rows = Int32.Parse(value);
                }
            }
            else if (name == "cols")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Columns = null;
                }
                else
                {
                    this.Columns = Int32.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Columns));
        }
    }
}
