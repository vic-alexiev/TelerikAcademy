using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace LoadingXmlInTreeView
{
    public partial class XmlLoader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string filePath = MapPath("Resources/Catalogue.xml");

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    this.LoadXmlDocumentInTree(fileStream);
                }
            }
        }

        protected void ButtonLoad_Click(object sender, EventArgs e)
        {
            var postedFile = FileUpload.PostedFile;

            if (postedFile != null &&
                !string.IsNullOrWhiteSpace(postedFile.FileName))
            {
                using (postedFile.InputStream)
                {
                    this.LoadXmlDocumentInTree(postedFile.InputStream);
                }
            }
        }

        private void LoadXmlDocumentInTree(Stream fileStream)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(fileStream);

            TreeViewFromXml.Nodes.Clear();
            TreeViewFromXml.Nodes.Add(new TreeNode(doc.DocumentElement.Name));

            TreeNode rootNode = TreeViewFromXml.Nodes[0];

            this.AddTreeNode(doc.DocumentElement, rootNode);
            TreeViewFromXml.ExpandAll();
        }

        private void AddTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            if (xmlNode.HasChildNodes)
            {
                XmlNodeList xmlNodeChildren = xmlNode.ChildNodes;
                for (int i = 0; i <= xmlNodeChildren.Count - 1; i++)
                {
                    XmlNode childXmlNode = xmlNodeChildren[i];

                    treeNode.ChildNodes.Add(new TreeNode(childXmlNode.Name));
                    TreeNode childTreeNode = treeNode.ChildNodes[i];

                    this.AddTreeNode(childXmlNode, childTreeNode);
                }
            }
            else
            {
                treeNode.Text = xmlNode.OuterXml.Trim();
            }
        }
    }
}