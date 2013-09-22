<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinksMenuDemo.aspx.cs" Inherits="TelerikAcademyControls.LinksMenuDemo" %>

<%@ Register src="LinksMenu.ascx" tagname="LinksMenu" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formLinksMenuDemo" runat="server">
        <div>
            <telerik:LinksMenu ID="LinksMenuFavourites" runat="server" />
        </div>
    </form>
</body>
</html>
