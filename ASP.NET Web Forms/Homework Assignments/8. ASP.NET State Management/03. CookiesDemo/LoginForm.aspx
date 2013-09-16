<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="CookiesDemo.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formLogin" runat="server">
    <div>
    
        <asp:Label ID="LabelUsername" runat="server" AssociatedControlID="TextBoxUsername" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="LabelPassword" runat="server" AssociatedControlID="TextBoxPassword" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
    
    </div>
    </form>
</body>
</html>
