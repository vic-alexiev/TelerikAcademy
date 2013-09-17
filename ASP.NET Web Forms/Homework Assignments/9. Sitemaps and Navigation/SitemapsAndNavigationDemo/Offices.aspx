<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Offices.aspx.cs"
    Inherits="SitemapsAndNavigationDemo.Offices" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Our offices</h1>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu"
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server"
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
