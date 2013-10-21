<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>
            <asp:Label ID="LabelSearchResults" runat="server">
            </asp:Label>
        </h1>
        <asp:Repeater ID="RepeaterBooksFound" runat="server" ItemType="LibrarySystem.Models.Book">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="BookDetails.aspx?id=<%#:Item.Id %>"><%#: Item.Title %></a>
                    <span>(Category: <%#: Item.Category.Name %>)</span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
