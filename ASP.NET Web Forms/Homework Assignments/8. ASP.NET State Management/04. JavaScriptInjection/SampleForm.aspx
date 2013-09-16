<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleForm.aspx.cs" Inherits="JavaScriptInjection.SampleForm" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formSample" runat="server">
        <div>

            <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="OK" />
            <br />
            <asp:Label ID="LabelInput" runat="server"></asp:Label>
            <br />
            <asp:Button ID="ButtonClickMe" runat="server" OnClick="ButtonClickMe_Click" Text="Click Me!" />
            <asp:Label ID="LabelClicks" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
