<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="TicTacToe.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="PanelGameBoard" runat="server" Height="213px" Width="929px">
                <asp:Button ID="Button0" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button1" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button2" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <br />
                <asp:Button ID="Button3" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button4" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button5" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <br />
                <asp:Button ID="Button6" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button7" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
                <asp:Button ID="Button8" runat="server" Height="70px" OnClick="Square_Click" Width="70px" />
            </asp:Panel>

        </div>
        <p>
            <asp:TextBox ID="TextBoxResult" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset" />
        </p>
    </form>
</body>
</html>
