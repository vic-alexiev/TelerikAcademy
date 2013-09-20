<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SimpleChat.Home" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <div>
            <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Timer ID="TimerRefresh" runat="server" Interval="500" OnTick="TimerRefresh_Tick" />

                    <asp:ListView ID="ListViewMessages" runat="server" DataKeyNames="Id"
                        SelectMethod="ListViewMessages_GetData" ItemType="SimpleChat.Message">
                        <AlternatingItemTemplate>
                            <span style="background-color: #FFF8DC;">Contents:
                <asp:Label ID="ContentsLabel" runat="server" Text='<%#: Item.Contents %>' />
                                <br />
                                Author:
                <asp:Label ID="AuthorLabel" runat="server" Text='<%#: Item.Author %>' />
                                <br />
                                Timestamp:
                <asp:Label ID="TimestampLabel" runat="server" Text='<%#: Item.Timestamp %>' />
                                <br />
                                <br />
                            </span>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <span>No data was returned.</span>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <span style="background-color: #DCDCDC; color: #000000;">Contents:
                <asp:Label ID="ContentsLabel" runat="server" Text='<%#: Item.Contents %>' />
                                <br />
                                Author:
                <asp:Label ID="AuthorLabel" runat="server" Text='<%#: Item.Author %>' />
                                <br />
                                Timestamp:
                <asp:Label ID="TimestampLabel" runat="server" Text='<%#: Item.Timestamp %>' />
                                <br />
                                <br />
                            </span>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                            <div style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <fieldset>
                <legend>New Message</legend>
                <asp:Label ID="LabelContents" runat="server" AssociatedControlID="TextBoxContents">Contents</asp:Label>
                <br />
                <asp:TextBox ID="TextBoxContents" MaxLength="250" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContents" runat="server" ControlToValidate="TextBoxContents" ErrorMessage="Contents is required." ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LabelAuthor" runat="server" AssociatedControlID="TextBoxAuthor">Author</asp:Label>
                <br />
                <asp:TextBox ID="TextBoxAuthor" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" runat="server" ControlToValidate="TextBoxAuthor" ErrorMessage="Author is required." ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="ButtonSendMessage" runat="server" OnClick="ButtonSendMessage_Click" Text="Send" />
                <br />
            <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
            </fieldset>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
