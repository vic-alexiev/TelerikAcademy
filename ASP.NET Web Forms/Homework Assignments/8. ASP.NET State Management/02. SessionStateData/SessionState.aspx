<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionState.aspx.cs" Inherits="SessionStateData.SessionState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formSessionState" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="OK" />
        <br />
        <asp:Label ID="LabelSessionContents" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
