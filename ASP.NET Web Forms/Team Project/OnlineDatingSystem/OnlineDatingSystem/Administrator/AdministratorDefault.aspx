<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministratorDefault.aspx.cs" Inherits="OnlineDatingSystem.Administrator.AdministratorDefault" %>

<asp:Content ID="AdminContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">
    <fieldset>
        <legend>Admin View</legend>

        <asp:ListView ID="UsersView" runat="server" 
            ItemType="OnlineDatingSystem.Models.ApplicationUser"
            DataKeyNames="Id"
            SelectMethod="UsersView_GetData"
            DeleteMethod="UsersView_DeleteItem">
            <LayoutTemplate>
                <table class="users-grid text-centered">
                    <thead>
                        <tr>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="Username">Username</asp:LinkButton></th>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="FirstName">First Name</asp:LinkButton></th>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="LastName">Last Name</asp:LinkButton></th>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="Email">Email</asp:LinkButton></th>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="City">City</asp:LinkButton></th>
                            <th><asp:LinkButton runat="server" CommandName="Sort" 
                                CommandArgument="Country">Country</asp:LinkButton></th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="itemPlaceholder" runat="server" class="row">
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="8"> Pages
                                <asp:DataPager PagedControlID="UsersView" runat="server" 
                                    PageSize="10">
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
                    <td class="span2"><%#: Item.UserName %></td>
                    <td class="span2"><%#: Item.FirstName %></td>
                    <td class="span2"><%#: Item.LastName %></td>
                    <td class="span2"><%#: Item.Email %></td>
                    <td class="span2"><%#: Item.City.Name %></td>
                    <td class="span1"><%#: Item.Country.Name %></td>
                    <td class="span1">
                        <a href='AdminUserEdit.aspx?userId=<%# Item.Id %>'
                            class="btn btn-mini btn-info">Edit</a>
                        <asp:Button ID="Delete" CommandName="Delete" runat="server" 
                            CssClass="btn btn-mini btn-danger" Text="X"
                            OnClientClick="return confirm('Do you want to delete ?');"/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView> 
        <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red"></asp:Label>
    </fieldset>
</asp:Content>
