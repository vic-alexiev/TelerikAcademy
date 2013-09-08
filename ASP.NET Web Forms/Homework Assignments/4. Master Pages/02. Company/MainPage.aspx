<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentPage" runat="server"
    ContentPlaceHolderID="ContentPlaceHolderPageContent">
    <h1 id="welcome-text">Welcome to Yoda Corporation Web Site</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/BG/Home.aspx"
        Text="BG" CssClass="bg-flag-icon" />
    <asp:HyperLink runat="server" NavigateUrl="~/EN/Home.aspx"
        Text="EN" CssClass="uk-flag-icon" />
</asp:Content>
