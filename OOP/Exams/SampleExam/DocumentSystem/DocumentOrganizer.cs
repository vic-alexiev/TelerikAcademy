using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
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
}
