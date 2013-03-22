using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentSystemForBGCoder
{
    #region The Class Library

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
                throw new ArgumentException(String.Format("Property '{0}' not found", name));
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

    public class DocumentOrganizer
    {
        #region Private Fields

        private IList<IDocument> documents;

        #endregion

        #region Constructors

        public DocumentOrganizer()
        {
            documents = new List<IDocument>();
        }

        #endregion

        #region Public Methods

        public string ExecuteCommand(string commandName, string[] attributes)
        {
            if (commandName == "AddTextDocument")
            {
                return AddTextDocument(attributes);
            }
            else if (commandName == "AddPDFDocument")
            {
                return AddPdfDocument(attributes);
            }
            else if (commandName == "AddWordDocument")
            {
                return AddWordDocument(attributes);
            }
            else if (commandName == "AddExcelDocument")
            {
                return AddExcelDocument(attributes);
            }
            else if (commandName == "AddAudioDocument")
            {
                return AddAudioDocument(attributes);
            }
            else if (commandName == "AddVideoDocument")
            {
                return AddVideoDocument(attributes);
            }
            else if (commandName == "ListDocuments")
            {
                return ListDocuments();
            }
            else if (commandName == "EncryptDocument")
            {
                return EncryptDocument(attributes[0]);
            }
            else if (commandName == "DecryptDocument")
            {
                return DecryptDocument(attributes[0]);
            }
            else if (commandName == "EncryptAllDocuments")
            {
                return EncryptAllDocuments();
            }
            else if (commandName == "ChangeContent")
            {
                return ChangeContent(attributes[0], attributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + commandName);
            }
        }

        #endregion

        #region Private Methods

        private string AddDocument(IDocument document, string[] attributes)
        {
            foreach (string attribute in attributes)
            {
                string[] tokens = attribute.Split(new char[] { '=' });
                string propertyName = tokens[0];
                string propertyValue = tokens[1];

                document.LoadProperty(propertyName, propertyValue);
            }

            if (String.IsNullOrWhiteSpace(document.Name))
            {
                return "Document has no name";
            }
            else
            {
                documents.Add(document);

                return "Document added: " + document.Name;
            }
        }

        private string AddTextDocument(string[] attributes)
        {
            return AddDocument(new TextDocument(), attributes);
        }

        private string AddPdfDocument(string[] attributes)
        {
            return AddDocument(new PDFDocument(), attributes);
        }

        private string AddWordDocument(string[] attributes)
        {
            return AddDocument(new WordDocument(), attributes);
        }

        private string AddExcelDocument(string[] attributes)
        {
            return AddDocument(new ExcelDocument(), attributes);
        }

        private string AddAudioDocument(string[] attributes)
        {
            return AddDocument(new AudioDocument(), attributes);
        }

        private string AddVideoDocument(string[] attributes)
        {
            return AddDocument(new VideoDocument(), attributes);
        }

        private string ListDocuments()
        {
            if (documents.Count > 0)
            {
                StringBuilder result = new StringBuilder();

                bool first = true;

                foreach (var doc in documents)
                {
                    if (first)
                    {
                        result.Append(doc);
                        first = false;
                    }
                    else
                    {
                        result.AppendFormat("\r\n{0}", doc);
                    }
                }

                return result.ToString();
            }
            else
            {
                return "No documents found";
            }
        }

        private string EncryptDocument(string name)
        {
            StringBuilder result = new StringBuilder();

            bool documentFound = false;

            foreach (IDocument document in documents)
            {
                if (document.Name == name)
                {
                    if (!documentFound)
                    {
                        documentFound = true;
                    }
                    else
                    {
                        result.Append("\r\n");
                    }

                    if (document is IEncryptable)
                    {
                        (document as IEncryptable).Encrypt();

                        result.AppendFormat("Document encrypted: {0}", document.Name);
                    }
                    else
                    {
                        result.AppendFormat("Document does not support encryption: {0}", document.Name);
                    }
                }
            }

            if (!documentFound)
            {
                result.AppendFormat("Document not found: {0}", name);
            }

            return result.ToString();
        }

        private string DecryptDocument(string name)
        {
            StringBuilder result = new StringBuilder();

            bool documentFound = false;

            foreach (IDocument document in documents)
            {
                if (document.Name == name)
                {
                    if (!documentFound)
                    {
                        documentFound = true;
                    }
                    else
                    {
                        result.Append("\r\n");
                    }

                    if (document is IEncryptable)
                    {
                        (document as IEncryptable).Decrypt();

                        result.AppendFormat("Document decrypted: {0}", document.Name);
                    }
                    else
                    {
                        result.AppendFormat("Document does not support decryption: {0}", document.Name);
                    }
                }
            }

            if (!documentFound)
            {
                result.AppendFormat("Document not found: {0}", name);
            }

            return result.ToString();
        }

        private string EncryptAllDocuments()
        {
            bool documentFound = false;

            foreach (IDocument document in documents)
            {
                if (document is IEncryptable)
                {
                    documentFound = true;

                    (document as IEncryptable).Encrypt();
                }
            }

            if (documentFound)
            {
                return "All documents encrypted";
            }
            else
            {
                return "No encryptable documents found";
            }
        }

        private string ChangeContent(string name, string newContent)
        {
            StringBuilder result = new StringBuilder();

            bool documentFound = false;

            foreach (IDocument document in documents)
            {
                if (document.Name == name)
                {
                    if (!documentFound)
                    {
                        documentFound = true;
                    }
                    else
                    {
                        result.Append("\r\n");
                    }

                    if (document is IEditable)
                    {
                        (document as IEditable).ChangeContent(newContent);

                        result.AppendFormat("Document content changed: {0}", document.Name);
                    }
                    else
                    {
                        result.AppendFormat("Document is not editable: {0}", document.Name);
                    }
                }
            }

            if (!documentFound)
            {
                result.AppendFormat("Document not found: {0}", name);
            }

            return result.ToString();
        }

        #endregion
    }

    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                return this.GetType().Name + "[encrypted]";
            }
            else
            {
                return base.ToString();
            }
        }
    }

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

    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string name, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }

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

    #endregion

    #region The Demo Console Application

    public class DocumentSystemDemo
    {
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(commandLine))
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            DocumentOrganizer docManager = new DocumentOrganizer();

            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");

                string command = commandLine.Substring(0, paramsStartIndex);

                int paramsEndIndex = commandLine.IndexOf("]");

                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);

                string[] attributes = parameters.Split(
                    new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string commandResult = docManager.ExecuteCommand(command, attributes);
                Console.WriteLine(commandResult);
            }
        }
    }

    #endregion
}
