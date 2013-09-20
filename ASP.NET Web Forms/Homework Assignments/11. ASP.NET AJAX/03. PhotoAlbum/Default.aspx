<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoAlbum.Default" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.0.3.min.js"></script>
</head>
<body>
    <form id="formDefault" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManagerSlider" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <fieldset>
            <legend>Ajax Control Toolkit Slideshow</legend>
            <asp:Image CssClass="image-holder" ID="ImageHolder" runat="server" />
            <ajaxToolkit:SlideShowExtender ID="ImageHolder_SlideShowExtender" runat="server"
                Enabled="True" ImageDescriptionLabelID="LabelDescription"
                SlideShowServiceMethod="GetSlides" AutoPlay="true"
                NextButtonID="ButtonNext" PreviousButtonID="ButtonPrevious"
                TargetControlID="ImageHolder" Loop="true">
            </ajaxToolkit:SlideShowExtender>
            <br />
            <asp:Button ID="ButtonPrevious" runat="server" Text="<" />
            <asp:Button ID="ButtonNext" runat="server" Text=">" />
            <asp:Label CssClass="description" ID="LabelDescription" runat="server"></asp:Label>
        </fieldset>
    </form>
    <script>
        (function () {
            $("#formDefault").on("click", ".image-holder", function (ev) {
                var path = $(".description").text();

                window.open(path + '.png', 'Popup', 'toolbar=no, location=yes, status=no, menubar=no, scrollbars=no, resizable=no, width=332, height=429, left=430, top=23');
            });
        })();
    </script>
</body>
</html>
