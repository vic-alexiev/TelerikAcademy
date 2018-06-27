<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="OnlineDatingSystem.SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend>Messages<br />

            <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Timer ID="TimerRefresh" runat="server" Interval="2000" OnTick="TimerRefresh_Tick" />

                    <asp:GridView ID="GridViewMessages" runat="server"
                        AllowSorting="True" AllowPaging="True" PageSize="5"
                        AutoGenerateColumns="False" DataKeyNames="Id" ItemType="OnlineDatingSystem.Models.Message"
                        OnPageIndexChanging="GridViewMessages_PageIndexChanging"
                        CssClass="table table-striped table-bordered table-condensed"
                        SelectMethod="GridViewMessages_GetData"
                        DeleteMethod="GridViewMessages_DeleteItem">

                        <Columns>
                            <asp:BoundField DataField="Id" Visible="false" />

                            <asp:TemplateField HeaderText="Content" SortExpression="Content">
                                <ItemTemplate>
                                    <%#: Item.Content.Length > 70 ? Item.Content.Substring(0, 70) + "..." : Item.Content %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Timestamp" SortExpression="Timestamp">
                                <ItemTemplate>
                                    <%#: Item.Timestamp.ToString("dd-MM-yyyy HH:mm:ss") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Author" SortExpression="Author.UserName">
                                <ItemTemplate>
                                    <%#: Item.Author.UserName %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Receiver" SortExpression="Receiver.UserName">
                                <ItemTemplate>
                                    <%#: Item.Receiver.UserName %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>

            <br />
            <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        </legend>
    </fieldset>

    <fieldset>
        <legend>New Message</legend>
        <asp:Label ID="LabelNewMessageContent" runat="server">Content</asp:Label>
        <asp:TextBox ID="TextBoxNewMessageContent" MaxLength="250" runat="server"></asp:TextBox>
        <asp:LinkButton ID="LinkButtonSendMessage" CssClass="ProfileButton" runat="server" OnClick="LinkButtonSendMessage_Click" Text="Send" />
    </fieldset>

</asp:Content>
