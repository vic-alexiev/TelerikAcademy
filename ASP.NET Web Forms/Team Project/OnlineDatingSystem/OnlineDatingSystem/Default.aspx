<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineDatingSystem._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>Online Dating System</h1>
    </div>
    <fieldset>
        <legend>Filter</legend>
        <asp:Label ID="LabelAgeFilter" runat="server" AssociatedControlID="TextBoxAgeFilterFrom">Age is between</asp:Label>

        <asp:TextBox ID="TextBoxAgeFilterFrom" runat="server" MaxLength="3"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidatorAgeFilterFrom" runat="server" ControlToValidate="TextBoxAgeFilterFrom" ErrorMessage="Value should be an integer." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <asp:Label ID="LabelAgeFilterTo" runat="server" AssociatedControlID="TextBoxAgeFilterTo" Text="and"></asp:Label>
        <asp:TextBox ID="TextBoxAgeFilterTo" runat="server" MaxLength="3"></asp:TextBox>

        <asp:CompareValidator ID="CompareValidatorAgeFilterTo" runat="server" ControlToValidate="TextBoxAgeFilterTo" ErrorMessage="Value should be an integer." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>

        <asp:Label ID="LabelSexFilter" runat="server" AssociatedControlID="DropDownListSexFilter">Sex is</asp:Label>
        <asp:DropDownList ID="DropDownListSexFilter" runat="server">
            <asp:ListItem Value="A">All</asp:ListItem>
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelCityFilter" runat="server" AssociatedControlID="DropDownListCityFilter">City is</asp:Label>
        <asp:DropDownList ID="DropDownListCityFilter" runat="server"
            DataValueField="Id" DataTextField="Name">
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButtonApplyFilter" CssClass="ProfileButton" runat="server" Text="Apply" OnClick="LinkButtonApplyFilter_Click" />
        <asp:LinkButton ID="LinkButtonRemoveFilter" CssClass="ProfileButton" runat="server" Text="Remove" OnClick="LinkButtonRemoveFilter_Click" />
    </fieldset>
    <fieldset>
        <legend>Users</legend>
        <asp:UpdatePanel ID="UpdatePanelUsers" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <asp:GridView ID="GridViewUsers" runat="server" AllowPaging="True" PageSize="5" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id"
                    ItemType="OnlineDatingSystem.Models.ApplicationUser" OnPageIndexChanging="GridViewUsers_PageIndexChanging"
                    CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="False" />

                        <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <img src='data:image/png;base64,<%# Item.Photo != null ? Convert.ToBase64String(Item.Photo) : string.Empty %>' alt="photo" height="50" width="100" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Username" SortExpression="Username">
                            <ItemTemplate>
                                <%#: Item.UserName%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Age" SortExpression="BirthDate">
                            <ItemTemplate>
                                <%#: GetAge(Item.BirthDate)%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sex">
                            <ItemTemplate>
                                <%#: Item.Sex%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <%#: Item.City.Name%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <%#: Item.Country.Name%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <%#: Item.Description%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="SendMessage.aspx?id={0}" Text="Send message" />

                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="UserDetails.aspx?id={0}" Text="Details" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </fieldset>
</asp:Content>
