<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebChat.Account.Register" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxUserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxUserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxPassword" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPassword"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxFirstName" CssClass="control-label" ID="LabelFirstName">First Name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxFirstName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstName"
                    CssClass="text-error" ErrorMessage="The First Name field is required." ID="RequiredFieldValidatorFirstName" />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxLastName" CssClass="control-label" ID="LabelLastName">Last Name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxLastName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastName"
                    CssClass="text-error" ErrorMessage="The Last Name field is required." ID="RequiredFieldValidatorLastName" />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="control-label" ID="LabelEmail">Email</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxEmail" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-error" ErrorMessage="The Email field is required." ID="RequiredFieldValidatorEmail" />
            </div>
        </div>
        <div class="form-actions no-color">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
        </div>
    </fieldset>

</asp:Content>
