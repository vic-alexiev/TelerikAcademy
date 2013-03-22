using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        /// <summary>
        /// Sample rate in Hz.
        /// </summary>
        public int? SampleRate { get; protected set; }

        public override void LoadProperty(string name, string value)
        {
            if (name == "samplerate")
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.SampleRate = null;
                }
                else
                {
                    this.SampleRate = Int32.Parse(value);
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
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
}
