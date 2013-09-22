<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalogClockDemo.aspx.cs" Inherits="TelerikAcademyControls.AnalogClockDemo" %>

<%@ Register Src="AnalogClock.ascx" TagName="AnalogClock" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formClock" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <telerik:AnalogClock ID="UserControlAnalogClock" runat="server" />

        <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Timer ID="TimerRefresh" runat="server" Interval="1000" OnTick="TimerRefresh_Tick" />
                <asp:Image ID="ImageClock" runat="server" Height="200px" Width="200px" />
                <br />
                <asp:TextBox ID="TextBoxTime" runat="server"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Label ID="LabelTimeZone" runat="server" AssociatedControlID="DropDownListTimeZone" Text="Change time zone"></asp:Label>

        <asp:UpdatePanel ID="UpdatePanelTimeZones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList
                    ID="DropDownListTimeZone"
                    AutoPostBack="true"
                    DataValueField="Id"
                    DataTextField="DisplayName"
                    runat="server" OnSelectedIndexChanged="DropDownListTimeZone_SelectedIndexChanged">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
