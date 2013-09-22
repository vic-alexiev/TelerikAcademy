<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinksMenu.ascx.cs" Inherits="TelerikAcademyControls.LinksMenu" %>

<asp:DataList
    ID="DataListLinksMenu"
    runat="server"
    RepeatDirection="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both">
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <ItemStyle ForeColor="#000066" />
    <ItemTemplate>
        <asp:HyperLink
            ID="HyperLinkMenuItem"
            runat="server"
            NavigateUrl='<%#: Eval("Url") %>'
            Target="_blank"
            Font-Underline="false"
            Text='<%#: Eval("Title") %>'>
        </asp:HyperLink>
    </ItemTemplate>
    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
</asp:DataList>