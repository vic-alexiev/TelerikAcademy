<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_01.Caching.About" %>

<%--<%@ OutputCache Duration="3600" VaryByParam="none" %>--%>
<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="telerik" TagName="CacheableUserControl" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Current time: <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") %>.</h2>
    </hgroup>

    <article>
        <telerik:CacheableUserControl runat="server" ID="CacheableUserControTest" />
    </article>


    <aside>
        <h3>Aside Title</h3>
        <p>
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About">About</a></li>
            <li><a runat="server" href="~/Contact">Contact</a></li>
        </ul>
    </aside>
</asp:Content>
