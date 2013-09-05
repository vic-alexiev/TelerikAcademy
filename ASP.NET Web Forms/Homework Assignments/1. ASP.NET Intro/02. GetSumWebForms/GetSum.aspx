<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSum.aspx.cs" Inherits="_02.GetSumWebForms.GetSum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 110px">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelFirstNumber" runat="server" AssociatedControlID="TextBoxFirstNumber" Text="First number"></asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelSecondNumber" runat="server" AssociatedControlID="TextBoxSecondNumber" Text="Second number"></asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="ButtonSum" runat="server" OnClick="ButtonSum_Click" Text="Sum" />
        <asp:TextBox ID="TextBoxResult" runat="server" ReadOnly="True"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
