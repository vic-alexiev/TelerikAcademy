<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>Web Chat</h1>
        <p class="lead">Web Chat is a web application which demonstrates the use of ASP.NET Identity.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>
    <fieldset>
        <legend>Messages</legend>
        <asp:Repeater ID="RepeaterMessages" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div><strong><%#: Eval("Author.FirstName") %> <%#: Eval("Author.LastName") %></strong> wrote:</div>
                    <p><%#: Eval("Contents") %></p>
                    <div><%#: Eval("Timestamp") %></div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:TextBox ID="TextBoxMessage" MaxLength="200" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:Button ID="ButtonSendMessage" runat="server" OnClick="ButtonSendMessage_Click" Text="Send" />
        <br />
        <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </fieldset>
</asp:Content>
