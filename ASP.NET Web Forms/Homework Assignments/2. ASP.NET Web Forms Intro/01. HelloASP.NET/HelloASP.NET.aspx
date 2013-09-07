<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloASP.NET.aspx.cs" Inherits="HelloASP.NET.HelloASP_NET" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelName" runat="server" AssociatedControlID="TextBoxName" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonSayHello" runat="server" OnClick="ButtonSayHello_Click" Text="Say Hello" />
        <asp:Label ID="LabelGreeting" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
