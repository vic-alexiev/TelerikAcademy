<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectFiles.aspx.cs" Inherits="_01.Caching.ProjectFiles" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Project Files, <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") %></h2>
    <h3>
        <asp:Literal ID="LiteralRootDirectory" runat="server" Mode="Encode"></asp:Literal></h3>
    <div>
        <ul>
            <asp:ListView
                ID="ListViewFiles"
                runat="server"
                ItemType="System.IO.FileInfo">
                <ItemTemplate>
                    <li><%#:Item.FullName %></li>
                </ItemTemplate>
            </asp:ListView>
        </ul>
    </div>
</asp:Content>
