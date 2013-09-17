<%@ Page Title="TreeView" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Sitemap.aspx.cs"
    Inherits="SitemapsAndNavigationDemo.Sitemap" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sitemap</h1>
    <p>This is the structure of our site:</p>
    <asp:TreeView ID="TreeViewSitePages" runat="server"
        DataSourceID="SiteMapDataSource" SkipLinkText="">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
</asp:Content>
