<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Registered.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <div>
        <asp:GridView ID="GridViewCategories" runat="server" CssClass="gridview"
            AllowSorting="True" AllowPaging="True" PageSize="5"
            AutoGenerateColumns="False" DataKeyNames="Id" ItemType="LibrarySystem.Models.Category"
            SelectMethod="GridViewCategories_GetData"
            DeleteMethod="GridViewCategories_DeleteItem"
            UpdateMethod="GridViewCategories_UpdateItem">
            <Columns>
                <asp:BoundField DataField="Id" Visible="false" />

                <asp:TemplateField HeaderText="Category Name" SortExpression="Name">
                    <ItemTemplate>
                        <%#: Item.Name %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="link-button"
                            ID="LinkButtonEditCategory"
                            OnClick="LinkButtonEditCategory_Click"
                            runat="server" Text="Edit"></asp:LinkButton>
                        <asp:LinkButton CssClass="link-button"
                            ID="LinkButtonDeleteCategory"
                            OnClick="LinkButtonDeleteCategory_Click"
                            runat="server" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:LinkButton CssClass="link-button" OnClick="LinkButtonNewCategory_Click" ID="LinkButtonNewCategory" runat="server" Text="Create New" />
    <br />
    <asp:Label ID="LabelErrorMessage" EnableViewState="false" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Panel CssClass="panel" ID="PanelNewCategory" runat="server" Visible="false">
        <h2>Create New Category</h2>
        <asp:Label ID="LabelNewCategory" runat="server" Text="Category:"></asp:Label>
        <asp:TextBox ID="TextBoxNewCategory" MaxLength="100" runat="server" placeholder="Enter category name..."></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCreate" runat="server" OnClick="LinkButtonCreate_Click" Text="Create" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelCreate" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>

    <asp:Panel CssClass="panel" ID="PanelEditCategory" runat="server" Visible="false">
        <h2>Edit Category</h2>
        <asp:Label ID="LabelEditCategory" runat="server" Text="Category:"></asp:Label>
        <asp:TextBox ID="TextBoxEditCategory" MaxLength="100" runat="server"></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonEdit" runat="server" OnClick="LinkButtonEdit_Click" Text="Save" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelEdit" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>

    <asp:Panel CssClass="panel" ID="PanelDeleteCategory" runat="server" Visible="false">
        <h2>Confirm Category Deletion?</h2>
        <asp:Label ID="LabelDeleteCategory" runat="server" Text="Category:"></asp:Label>
        <asp:TextBox ID="TextBoxDeleteCategory" MaxLength="100" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonDelete" runat="server" OnClick="LinkButtonDelete_Click" Text="Yes" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelDelete" runat="server" Text="No" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>
</asp:Content>
