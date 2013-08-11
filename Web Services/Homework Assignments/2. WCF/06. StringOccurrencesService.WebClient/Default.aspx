<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StringOccurrencesService.WebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelSourceString" runat="server" Text="Source string:"></asp:Label>
        <asp:TextBox ID="TextBoxSourceString" runat="server"></asp:TextBox>
    
    </div>
        <asp:Label ID="LabelTargetString" runat="server" Text="Target string:"></asp:Label>
        <asp:TextBox ID="TextBoxTargetString" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="ButtonCountOccurrences" runat="server" OnClick="ButtonCountOccurrences_Click" Text="Occurrences" />
        </p>
        <p>
            <asp:Label ID="LabelOccurrences" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
