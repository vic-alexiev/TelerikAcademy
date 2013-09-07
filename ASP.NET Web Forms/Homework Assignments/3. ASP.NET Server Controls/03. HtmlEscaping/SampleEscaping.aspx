<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleEscaping.aspx.cs" Inherits="HtmlEscaping.SampleEscaping" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelInput" runat="server" AssociatedControlID="TextBoxInput" Text="Enter some text"></asp:Label>
    
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonGo" runat="server" OnClick="ButtonGo_Click" Text="Go" />
    
    </div>
        <p>
            <asp:TextBox ID="TextBoxOutput" runat="server"></asp:TextBox>
            <asp:Label ID="LabelOutput" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
