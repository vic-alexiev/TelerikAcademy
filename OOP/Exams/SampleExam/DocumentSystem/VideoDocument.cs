using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        /// <summary>
        /// Frame rate in fps.
        /// </summary>
        public int? FrameRate { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "framerate")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.FrameRate = null;
                }
                else
                {
                    this.FrameRate = Int32.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
}
