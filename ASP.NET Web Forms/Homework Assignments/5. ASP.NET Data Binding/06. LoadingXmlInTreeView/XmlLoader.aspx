<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlLoader.aspx.cs" Inherits="LoadingXmlInTreeView.XmlLoader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formXmlLoader" runat="server">
        <div>

            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Button ID="ButtonLoad" runat="server" OnClick="ButtonLoad_Click" Text="Load" />
            <br />

            <asp:TreeView ID="TreeViewFromXml" runat="server" CollapseImageUrl="~/Resources/collapse.gif" ExpandImageUrl="~/Resources/exp.gif" NoExpandImageUrl="~/Resources/dropdown.gif">
            </asp:TreeView>

        </div>
    </form>
</body>
</html>
