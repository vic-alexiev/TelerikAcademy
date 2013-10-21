<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="form-search pull-right">
            <div class="input-append">
                <asp:TextBox ID="TextBoxSearchBooks" CssClass="span3 search-query" runat="server" placeholder="Seach by book title / author..."></asp:TextBox>
                <asp:Button ID="ButtonSearchBooks" CssClass="btn search-query" runat="server" OnClick="ButtonSearchBooks_Click" Text="Search" />
            </div>
        </div>
        <h1>Books</h1>
    </div>
    <div>
        <asp:ListView ID="ListViewCategories" runat="server"
            ItemType="LibrarySystem.Models.Category"
            GroupItemCount="3">

            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
            </LayoutTemplate>

            <GroupTemplate>
                <div class="row-fluid">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
            </GroupTemplate>

            <ItemTemplate>
                <div class="span4">
                    <h2><%#: Item.Name %></h2>
                    <ul>
                        <asp:Repeater ID="RepeaterBooks" runat="server"
                            DataSource="<%# Item.Books %>"
                            ItemType="LibrarySystem.Models.Book">
                            <ItemTemplate>
                                <li><a href="BookDetails.aspx?id=<%#: Item.Id %>"><%#: Item.Title %> <em>by <%#: Item.Author %></em></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
