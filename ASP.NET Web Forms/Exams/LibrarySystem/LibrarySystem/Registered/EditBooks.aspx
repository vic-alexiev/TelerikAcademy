<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Registered.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Books</h1>
    <asp:ListView ID="ListViewBooks" runat="server"
        ItemType="LibrarySystem.Models.Book"
        DataKeyNames="Id"
        SelectMethod="ListViewBooks_GetData"
        DeleteMethod="ListViewBooks_DeleteItem">
        <LayoutTemplate>
            <table class="gridview">
                <thead>
                    <tr>

                        <th>
                            <asp:LinkButton runat="server" CommandName="Sort"
                                CommandArgument="Name">Book Title</asp:LinkButton></th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager PagedControlID="ListViewBooks" runat="server"
                                PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Title %></td>
                <td>
                    <asp:LinkButton ID="ButtonEdit" CommandName="Edit"
                        CommandArgument="<%# Item.Id %>" runat="server"
                        OnCommand="ButtonEdit_Command"
                        CssClass="link-button" Text="Edit" />
                    <asp:LinkButton ID="ButtonDelete" CommandName="Delete"
                        runat="server"
                        CssClass="link-button" Text="Delete"
                        OnClientClick="return confirm('Do you want to delete ?');" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:LinkButton CssClass="link-button" OnClick="LinkButtonNewBook_Click" ID="LinkButtonNewBook" runat="server" Text="Create New" />
    <br />
    <asp:Label ID="LabelErrorMessage" EnableViewState="false" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Panel CssClass="panel" ID="PanelNewBook" runat="server" Visible="false">
        <h2>Create New Book</h2>
        <asp:Label ID="LabelNewBook" runat="server" Text="Book:"></asp:Label>
        <asp:TextBox ID="TextBoxNewBook" MaxLength="100" runat="server" placeholder="Enter book title..."></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCreate" runat="server" OnClick="LinkButtonCreate_Click" Text="Create" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelCreate" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>

    <asp:Panel CssClass="panel" ID="PanelEditBook" runat="server" Visible="false">
        <h2>Edit Book</h2>
        <asp:Label ID="LabelEditBook" runat="server" Text="Book:"></asp:Label>
        <asp:TextBox ID="TextBoxEditBook" MaxLength="100" runat="server"></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonEdit" runat="server" OnClick="LinkButtonEdit_Click" Text="Save" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelEdit" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>

</asp:Content>
