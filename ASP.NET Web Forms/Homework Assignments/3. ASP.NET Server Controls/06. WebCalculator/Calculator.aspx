<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="PanelScreen" runat="server">
                <asp:TextBox ID="TextBoxScreen" runat="server" ReadOnly="True"></asp:TextBox>
            </asp:Panel>

        </div>
        <asp:Panel ID="PanelOperations" runat="server">
            <asp:Button ID="Button1" runat="server" Text="1" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button2" runat="server" Text="2" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button3" runat="server" Text="3" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonPlus" runat="server" Text="+" OnClick="ButtonOperation_Click" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="4" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button5" runat="server" Text="5" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button6" runat="server" Text="6" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonMinus" runat="server" Text="-" OnClick="ButtonOperation_Click" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="7" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button8" runat="server" Text="8" OnClick="ButtonDigit_Click" />
            <asp:Button ID="Button9" runat="server" Text="9" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonMultiply" runat="server" Text="*" OnClick="ButtonOperation_Click" />
            <br />
            <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" />
            <asp:Button ID="Button0" runat="server" Text="0" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonDivide" runat="server" Text="/" OnClick="ButtonOperation_Click" />
            <asp:Button ID="ButtonSqrt" runat="server" Text="√" OnClick="ButtonOperation_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelEquals" runat="server">
            <asp:Button ID="ButtonEquals" runat="server" Text="=" OnClick="ButtonEquals_Click" />
        </asp:Panel>
    </form>
</body>
</html>
