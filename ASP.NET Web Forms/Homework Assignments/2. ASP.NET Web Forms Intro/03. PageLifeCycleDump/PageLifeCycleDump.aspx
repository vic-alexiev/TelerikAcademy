<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageLifeCycleDump.aspx.cs" Inherits="PageLifeCycleDump.PageLifeCycleDump" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" OnDisposed="ButtonOK_Disposed" OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" Text="OK" />
    
    </div>
    </form>
</body>
</html>
